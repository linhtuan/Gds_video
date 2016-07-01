using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace MvcCornerstone.Data
{
    public interface IEntityRepository<T> where T : class
    {
        T GetById<TC>(object id) where TC : DbContext;

        void Insert<TC>(T entity) where TC : DbContext;

        int Commit<TC>() where TC : DbContext;

        void Delete<TC>(T entity) where TC : DbContext;

        int DeleteMany(IQueryable<T> query);

        int DeleteMany<TC>(Expression<Func<T, bool>> expression) where TC : DbContext;

        IQueryable<T> DoQuery<TC>(Expression<Func<T, bool>> expression) where TC : DbContext;

        void InsertMany<TC>(IEnumerable<T> insertList) where TC : DbContext;

        DbSet<T> Table<TC>() where TC : DbContext;

        void Update<TC>(T entity) where TC : DbContext;

        void UpdateMany<TC>(IEnumerable<T> items) where TC : DbContext;

        int UpdateMany<TC>(Expression<Func<T, bool>> queryExpression, Expression<Func<T, T>> updateExpression) where TC : DbContext;

        int UpdateMany<TC>(IQueryable<T> query, Expression<Func<T, T>> updateExpression) where TC : DbContext;

        int ExecuteSqlCommand<TC>(string sql) where TC : DbContext;

        DbRawSqlQuery<T1> SqlQuery<TC, T1>(string sql) where TC : DbContext where T1 : class;
    }
}
