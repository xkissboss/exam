using Exam.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {

        #region 增加
        Task<TEntity> InsertAsync(TEntity entity);
        TEntity Insert(TEntity entity);

        Task<List<TEntity>> InsertListAsync(List<TEntity> entityList);
        List<TEntity> InsertList(List<TEntity> entityList);
        #endregion

        #region 删除

        bool Delete(TEntity entity);
        
        Task<bool> DeleteAsync(TEntity entity);


        bool Delete(string id);

        Task<bool> DeleteAsync(string id);

        bool Delete(FilterDefinition<TEntity> filter);

        Task<bool> DeleteAsync(FilterDefinition<TEntity> filter);

        #endregion

        #region 修改

        TEntity Update(TEntity entity);

       
        Task<TEntity> UpdateAsync(TEntity entity);

        
        bool Update(string id, UpdateDefinition<TEntity> update);


        Task<bool> UpdateAsync(string id, UpdateDefinition<TEntity> update);

        bool Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);

        Task<bool> UpdateAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update);

        #endregion


        #region 查询
        IQueryable<TEntity> GetAll();

        List<TEntity> GetAllList();

        Task<List<TEntity>> GetAllListAsync();

        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicat);

        
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicat);

        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);


        TEntity Get(string id);

        Task<TEntity> GetAsync(string id);

        Task<List<TEntity>> GetFindAsync(FilterDefinition<TEntity> filter, FindOptions<TEntity, TEntity> options = null);

        Task<TEntity> GetFindSingleAsync(FilterDefinition<TEntity> filter, FindOptions<TEntity, TEntity> options = null);
        #endregion

        #region 聚合
        long Count();

       
        Task<long> CountAsync();


        long Count(Expression<Func<TEntity, bool>> predicate);

      
        Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate);

      
        long LongCount();

      
        Task<long> LongCountAsync();

       
        long LongCount(Expression<Func<TEntity, bool>> predicate);

        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);
        #endregion

    }
}
