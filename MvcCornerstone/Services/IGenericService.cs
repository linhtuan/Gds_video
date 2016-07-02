using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MvcCornerstone.Data;

namespace MvcCornerstone.Services
{
    public interface IGenericService<TRecord, TC> where TRecord : class where TC: DbContext
    {
        int Count(Expression<Func<TRecord, bool>> predicate = null);

        Task<int> CountAsync(Expression<Func<TRecord, bool>> predicate = null);

        void Delete(TRecord record);

        Task DeleteAsync(TRecord record);

        void DeleteMany(IEnumerable<TRecord> records);

        Task DeleteManyAsync(IEnumerable<TRecord> records);

        void Delete(Expression<Func<TRecord, bool>> filterExpression);

        Task DeleteAsync(Expression<Func<TRecord, bool>> filterExpression);

        TRecord GetById(object id);

        Task<TRecord> GetByIdAsync(object id);

        IQueryable<TRecord> GetRecords();

        Task<IEnumerable<TRecord>> GetRecordsAsync();

        Task<IEnumerable<TResult>> GetFromRecordsAsync<TResult>(Expression<Func<TRecord, bool>> predicate, Func<TRecord, TResult> selector);

        void Insert(TRecord record);

        Task InsertAsync(TRecord record);

        void InsertMany(IEnumerable<TRecord> records);

        Task InsertManyAsync(IEnumerable<TRecord> records);

        void Update(TRecord record);

        Task UpdateAsync(TRecord record);

        void UpdateMany(IEnumerable<TRecord> records);

        Task UpdateManyAsync(IEnumerable<TRecord> records);

        void UpdateMany(Expression<Func<TRecord, bool>> filterExpression, Expression<Func<TRecord, TRecord>> updateExpression);

        Task UpdateManyAsync(Expression<Func<TRecord, bool>> filterExpression, Expression<Func<TRecord, TRecord>> updateExpression);
    }

    public abstract class GenericService<TRecord, TC> : IGenericService<TRecord, TC> where TRecord : class where TC : DbContext
    {
        protected readonly IEntityRepository<TRecord> Repository;

        protected GenericService(IEntityRepository<TRecord> repository)
        {
            Repository = repository;
        }

        protected virtual string BuildCacheKey(string key)
        {
            return key;
        }


        #region IGenericService<TRecord> Members

        public int Count(Expression<Func<TRecord, bool>> predicate = null)
        {
            return predicate == null ? Repository.Table<TC>().Count() : Repository.Table<TC>().Count(predicate);
        }

        public Task<int> CountAsync(Expression<Func<TRecord, bool>> predicate = null)
        {
            return Task.FromResult(Count(predicate));
        }

        public virtual void Delete(TRecord record)
        {
            Repository.Delete<TC>(record);
        }

        public Task DeleteAsync(TRecord entity)
        {
            Delete(entity);
            return Task.FromResult(true);
        }


        public virtual void DeleteMany(IEnumerable<TRecord> records)
        {
            Repository.DeleteMany(records.AsQueryable());
        }

        public Task DeleteManyAsync(IEnumerable<TRecord> records)
        {
            DeleteMany(records);
            return Task.FromResult(true);
        }

        public void Delete(Expression<Func<TRecord, bool>> filterExpression)
        {
            Repository.DeleteMany<TC>(filterExpression);
        }

        public Task DeleteAsync(Expression<Func<TRecord, bool>> filterExpression)
        {
            Delete(filterExpression);
            return Task.FromResult(true);
        }

        public virtual TRecord GetById(object id)
        {
            return Repository.GetById<TC>(id);
        }

        public Task<TRecord> GetByIdAsync(object id)
        {
            return Task.FromResult(GetById(id));
        }

        public virtual IQueryable<TRecord> GetRecords()
        {
            var query = Repository.Table<TC>();
            return query;
        }

        public Task<IEnumerable<TRecord>> GetRecordsAsync()
        {
            return Task.FromResult(GetRecords().AsEnumerable());
        }

        public Task<IEnumerable<TResult>> GetFromRecordsAsync<TResult>(Expression<Func<TRecord, bool>> predicate, Func<TRecord, TResult> selector)
        {
            throw new NotImplementedException();
        }

        public virtual void Insert(TRecord record)
        {
            //record.OnInserting();
            Repository.Insert<TC>(record);
        }

        public Task InsertAsync(TRecord record)
        {
            Insert(record);
            return Task.FromResult(true);
        }

        public virtual void InsertMany(IEnumerable<TRecord> records)
        {
            if (!records.Any())
            {
                return;
            }

            Repository.InsertMany<TC>(records);
        }

        public Task InsertManyAsync(IEnumerable<TRecord> records)
        {
            if (!records.Any())
            {
                return Task.FromResult(true);
            }

            InsertMany(records);
            return Task.FromResult(true);
        }

        public virtual void Update(TRecord record)
        {
            Repository.Update<TC>(record);
        }

        public Task UpdateAsync(TRecord record)
        {
            Update(record);
            return Task.FromResult(true);
        }

        public virtual void UpdateMany(IEnumerable<TRecord> records)
        {
            Repository.UpdateMany<TC>(records);
        }

        public Task UpdateManyAsync(IEnumerable<TRecord> records)
        {
            UpdateMany(records);
            return Task.FromResult(true);
        }

        public void UpdateMany(Expression<Func<TRecord, bool>> filterExpression, Expression<Func<TRecord, TRecord>> updateExpression)
        {
            Repository.UpdateMany<TC>(filterExpression, updateExpression);
        }

        public Task UpdateManyAsync(Expression<Func<TRecord, bool>> filterExpression, Expression<Func<TRecord, TRecord>> updateExpression)
        {
            UpdateMany(filterExpression, updateExpression);
            return Task.FromResult(true);
        }

        #endregion IGenericService<TRecord> Members
    }
}
