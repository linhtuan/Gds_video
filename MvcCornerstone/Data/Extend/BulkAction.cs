using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace MvcCornerstone.Data.Extend
{
    public class BulkAction
    {
        public static int Delete<T>(ObjectQuery<T> query) where T : class
        {
            var context = query.Context;
            var mapping = GetMapping(context, typeof(T));
            var innerSelect = GetSelectSql(query, mapping.KeyMembers);
            var sqlBuilder = new StringBuilder(innerSelect.Sql.Length * 2);
            sqlBuilder.AppendFormat("DELETE {0}\n", mapping.TableName);
            sqlBuilder.AppendFormat("FROM {0} as j0 INNER JOIN (\n", mapping.TableName);
            sqlBuilder.Append(innerSelect.Sql);
            sqlBuilder.Append(") as j1 on (");
            sqlBuilder.Append(String.Join(" AND ", mapping.KeyMembers.Select(k => String.Format("(j0.{0} = j1.{0})", k.Name))));
            sqlBuilder.AppendLine(")");

            return context.ExecuteStoreCommand(sqlBuilder.ToString(), innerSelect.Parameters.ToArray<object>());
        }

        public static int Update<T>(ObjectQuery<T> query, Expression<Func<T, T>> updateExpression) where T : class
        {
            var context = query.Context;
            var mapping = GetMapping(context, typeof(T));
            var innerSelect = GetSelectSql(query, mapping.KeyMembers);
            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendFormat("UPDATE {0}\n", mapping.TableName);
            sqlBuilder.AppendLine("SET");
            // Build set value 
            var memberUpdateExpression = updateExpression.Body as MemberInitExpression;
            if (memberUpdateExpression == null)
                throw new ArgumentException("The update expression must be of type MemberInitExpression.", "updateExpression");

            int nameCount = 0;
            bool comma = false;
            foreach (MemberBinding binding in memberUpdateExpression.Bindings)
            {
                if (comma)
                    sqlBuilder.Append(",");

                var propertyName = binding.Member.Name;
                var columnName = mapping.EntitySet
                                        .ElementType
                                        .DeclaredMembers
                                        .Where(e => e.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                                        .Select(e => e.Name)
                                        .SingleOrDefault();
                object value = null;

                if (string.IsNullOrEmpty(columnName))
                    throw new ArgumentException("The update expression column does not match.", "updateExpression");

                var memberAssignment = binding as MemberAssignment;
                if (memberAssignment == null)
                    throw new ArgumentException("The update expression MemberBinding must only by type MemberAssignment.", "updateExpression");

                Expression memberExpression = memberAssignment.Expression;
                if (memberExpression.NodeType == ExpressionType.Constant)
                {
                    var constantExpression = memberExpression as ConstantExpression;
                    value = constantExpression.Value;
                }
                else
                {
                    LambdaExpression lambda = Expression.Lambda(memberExpression, null);
                    value = lambda.Compile().DynamicInvoke();
                }

                if (value != null)
                {
                    string parameterName = "p__update__" + nameCount++;
                    var parameter = new SqlParameter();
                    parameter.ParameterName = parameterName;
                    parameter.Value = value;

                    sqlBuilder.AppendFormat("[{0}] = @{1}\n", columnName, parameterName);
                    innerSelect.Parameters.Add(parameter);
                }

                comma = true;
            }

            sqlBuilder.AppendFormat("FROM {0} as j0 INNER JOIN (\n", mapping.TableName);
            sqlBuilder.Append(innerSelect.Sql);
            sqlBuilder.Append(") as j1 on (");
            sqlBuilder.Append(String.Join(" AND ", mapping.KeyMembers.Select(k => String.Format("(j0.{0} = j1.{0})", k.Name))));
            sqlBuilder.AppendLine(")");

            return context.ExecuteStoreCommand(sqlBuilder.ToString(), innerSelect.Parameters.ToArray<object>());
        }

        public static void InsertMany<T>(DbContext context, IEnumerable<T> inserted) where T : class
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            var mapping = GetMapping(objectContext, typeof(T));
            var connection = context.Database.Connection as SqlConnection;
            using (var bulkCopy = new SqlBulkCopy(connection))
            {
                var table = new DataTable();
                bulkCopy.BatchSize = 1000;
                bulkCopy.DestinationTableName = mapping.TableName;

                // Generate data column from entity set
                //
                IEnumerable<string> columns = mapping.EntitySet.ElementType.DeclaredMembers.Select(t => t.Name);
                foreach (var item in columns)
                {
                    table.Columns.Add(item);
                    bulkCopy.ColumnMappings.Add(item, item);
                }

                // Binding data into datatable
                //
                foreach (var item in inserted)
                {
                    var properties = item.GetType().GetProperties();
                    DataRow row = table.NewRow();
                    foreach (var column in columns)
                    {
                        object value = DBNull.Value;
                        PropertyInfo propertyInfo = properties.FirstOrDefault(t => t.Name.Equals(column, StringComparison.InvariantCultureIgnoreCase));
                        if (propertyInfo != null)
                        {
                            value = propertyInfo.GetValue(item, null);
                            row[column] = value;
                        }
                    }

                    table.Rows.Add(row);
                }

                table.AcceptChanges();
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                bulkCopy.WriteToServer(table);
            }
        }

        private static EntitySet GetEntitySet(ObjectContext context, Type type, out Type setType)
        {
            setType = type;

            var metadata = context.MetadataWorkspace;
            var objectItemCollection = (ObjectItemCollection)metadata.GetItemCollection(DataSpace.OSpace);
            var entityType = metadata.GetItems<EntityType>(DataSpace.OSpace)
                                     .Single(e => objectItemCollection.GetClrType(e) == type);

            var entitySet = metadata.GetItems(DataSpace.CSpace)
                                    .Where(e => e.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                                    .Cast<EntityType>()
                                    .Single(e => e.Name == entityType.Name);

            var entityMappings = metadata.GetItems<EntityContainerMapping>(DataSpace.CSSpace)
                                         .Single().EntitySetMappings.ToList();

            EntitySet table = null;
            var mapping = entityMappings.SingleOrDefault(e => e.EntitySet.ElementType.FullName == entitySet.FullName);
            if (mapping != null)
            {
                table = mapping.EntityTypeMappings.Single().Fragments.Single().StoreEntitySet;
                return table;
            }

            return table;
        }

        private static MappingAPI GetMapping(ObjectContext context, Type type)
        {
            Type setType;
            var entitySet = GetEntitySet(context, type, out setType);
            if (entitySet == null)
                return null;

            var item = new MappingAPI
            {
                EntitySet = entitySet,
                SetType = setType,
                TableName = String.Format("[{0}].[{1}]", (string)entitySet.MetadataProperties["Schema"].Value ?? "dbo",
                                            (string)entitySet.MetadataProperties["Table"].Value ?? entitySet.Name),
                KeyMembers = entitySet.ElementType.KeyMembers
            };

            return item;
        }

        private static InnerSelect GetSelectSql(ObjectQuery query, ICollection<EdmMember> keys)
        {
            var innerSelect = new InnerSelect();
            var selector = String.Format("new({0})", String.Join(", ", keys.Select(k => k.Name)));
            var selectQuery = DynamicQueryable.Select(query, selector) as ObjectQuery;
            innerSelect.Sql = selectQuery.ToTraceString();
            foreach (var item in selectQuery.Parameters)
            {
                var param = new SqlParameter();
                param.ParameterName = item.Name;
                param.Value = item.Value ?? DBNull.Value;
                innerSelect.Parameters.Add(param);
            }

            return innerSelect;
        }

        private class InnerSelect
        {
            public InnerSelect()
            {
                Parameters = new List<DbParameter>();
            }

            public List<DbParameter> Parameters { get; set; }

            public string Sql { get; set; }
        }

        private class MappingAPI
        {
            public EntitySet EntitySet { get; set; }

            public ICollection<EdmMember> KeyMembers { get; set; }

            public Type SetType { get; set; }

            public string TableName { get; set; }

        }
    }
}
