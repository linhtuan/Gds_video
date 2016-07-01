using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using MvcCornerstone.Data.Extend;
using MvcCornerstone.Factory;

namespace MvcCornerstone.Data.Entity
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class 
    {
        private readonly IDaoFactory _factory;

        public EntityRepository(IDaoFactory factory)
        {
            _factory = factory;
        }

        public T GetById<TC>(object id) where TC : DbContext
        {
            var context = RetrieveContext<TC>();
            return context.Set<T>().Find(id);
        }

        public void Insert<TC>(T entity) where TC : DbContext
        {
            var context = RetrieveContext<TC>();
            context.Entry(entity).State = EntityState.Added;
        }

        public int Commit<TC>() where TC : DbContext
        {
            var context = RetrieveContext<TC>();
            context.Configuration.ValidateOnSaveEnabled = false;
            return context.SaveChanges();
        }

        public void Delete<TC>(T entity) where TC : DbContext
        {
            var context = RetrieveContext<TC>();
            context.Entry(entity).State = EntityState.Deleted;
        }

        public int DeleteMany(IQueryable<T> query)
        {
            return BulkAction.Delete(query.ToObjectQuery());
        }

        public int DeleteMany<TC>(Expression<Func<T, bool>> expression) where TC : DbContext
        {
            var context = RetrieveContext<TC>();
            var query = context.Set<T>().Where(expression);
            return BulkAction.Delete(query.ToObjectQuery());
        }

        public IQueryable<T> DoQuery<TC>(Expression<Func<T, bool>> expression) where TC : DbContext
        {
            return Table<TC>().Where(expression).AsQueryable();
        }

        public void InsertMany<TC>(IEnumerable<T> insertList) where TC : DbContext
        {
            var context = RetrieveContext<TC>();
            if (context == null)
                throw new NullReferenceException("Could not found instance of context");

            BulkAction.InsertMany(context, insertList);
        }

        public DbSet<T> Table<TC>() where TC : DbContext
        {
            var context = RetrieveContext<TC>();
            return context.Set<T>();
        }

        public void Update<TC>(T entity) where TC : DbContext
        {
            var context = RetrieveContext<TC>();
            var isAttached = false;
            if (context.Entry(entity).State == EntityState.Detached)
            {
                var entities = context.Set<T>();
                var hashCode = entity.GetHashCode();
                foreach (var obj in entities.Local)
                {
                    if (obj.GetHashCode() != hashCode) continue;
                    context.Entry(obj).CurrentValues.SetValues(entity);
                    isAttached = true;
                    break;
                }

                if (isAttached) return;

                entity = entities.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void UpdateMany<TC>(IEnumerable<T> items) where TC : DbContext
        {
            if (items == null)
                throw new ArgumentNullException("items");
            var context = RetrieveContext<TC>();
            var set = context.Set<T>();
            foreach (var entity in items)
            {
                if (context.Entry(entity).State == EntityState.Detached)
                    set.Attach(entity);

                // Set the entity's state to modified
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public int UpdateMany<TC>(Expression<Func<T, bool>> queryExpression, Expression<Func<T, T>> updateExpression) where TC : DbContext
        {
            var context = RetrieveContext<TC>();
            var query = context.Set<T>().Where(queryExpression);
            return BulkAction.Update(query.ToObjectQuery(), updateExpression);
        }

        public int UpdateMany<TC>(IQueryable<T> query, Expression<Func<T, T>> updateExpression) where TC : DbContext
        {
            return BulkAction.Update(query.ToObjectQuery(), updateExpression);
        }


        public int ExecuteSqlCommand<TC>(string sql) where TC : DbContext
        {
            var ctx = _factory.GetContext<TC>();
            return DoWithRetry(() => ctx.Database.ExecuteSqlCommand(sql));
        }

        public DbRawSqlQuery<T1> SqlQuery<TC, T1>(string sql) where TC : DbContext where T1 : class
        {
            var context = RetrieveContext<TC>();
            var result = context.Database.SqlQuery<T1>(sql);
            return result;
        }

        private int DoWithRetry(Action action, int timeToSleep = 1000, int retryTime = 3)
        {
            while (true)
            {
                try
                {
                    action();
                    return 1;
                }
                catch
                {
                    if (--retryTime == 0)
                        throw;

                    Thread.Sleep(timeToSleep);
                }
            }
        }

        private TC RetrieveContext<TC>() where TC : DbContext
        {
            var ctx = _factory.GetContext<TC>();
            if (ctx == null)
                throw new NullReferenceException("Could not found instance of context");

            return ctx;
        }
    }
}
