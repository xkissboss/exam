using Exam.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;

namespace Exam.Repository
{
    public  class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly IMongoCollection<TEntity> mongoCollection;
        public Repository(IMongoDatabase mongoDatabase)
        {
            mongoCollection = mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        #region 查询
        
        public virtual TEntity Get(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var entity = mongoCollection.Find(filter).FirstOrDefault();
            return entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return mongoCollection.AsQueryable();
        }

        public virtual List<TEntity> GetAllList()
        {
            return this.GetAll().ToList();
        }

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return this.GetAll().Where(predicate).ToList();
        }

        public virtual async Task<List<TEntity>> GetAllListAsync()
        {
            var filter = Builders<TEntity>.Filter.Empty;
            var list = await mongoCollection.FindAsync(filter);
            return await list.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var filter = Builders<TEntity>.Filter.Empty;
            var list = await mongoCollection.FindAsync(predicate);
            return await list.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var list = await mongoCollection.FindAsync(filter);
            return await list.FirstOrDefaultAsync();

        }

        public virtual async Task<List<TEntity>> GetFindAsync(FilterDefinition<TEntity> filter, FindOptions<TEntity, TEntity> options = null)
        {
            //FilterDefinitionBuilder<TEntity> builder = new FilterDefinitionBuilder<TEntity>();
            //FilterDefinition<TEntity> filter1 = Builders<TEntity>.Filter.And(Builders<TEntity>.Filter.Eq("Name", "kkk5"), Builders<TEntity>.Filter.Gte("Age", 2));
            //filter = Builders<TEntity>.Filter.Or(filter, Builders<TEntity>.Filter.Eq("Name", "kkk1"));

            //builder.Eq(e => e.IsDeleted == false, "");
            var list = await mongoCollection.FindAsync(filter, options);
            return await list.ToListAsync();
        }

        public virtual async Task<TEntity> GetFindSingleAsync(FilterDefinition<TEntity> filter, FindOptions<TEntity, TEntity> options = null)
        {
            var list = await mongoCollection.FindAsync(filter, options);
            return await list.FirstOrDefaultAsync();
        }

        

        public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            return queryMethod(GetAll());
        }
        #endregion

        #region 增加
        public virtual TEntity Insert(TEntity entity)
        {
            mongoCollection.InsertOne(entity);
            return entity;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            await mongoCollection.InsertOneAsync(entity);
            return entity;
        }

        public virtual List<TEntity> InsertList(List<TEntity> entityList)
        {
            mongoCollection.InsertMany(entityList);
            return entityList;
        }

        public virtual async Task<List<TEntity>> InsertListAsync(List<TEntity> entityList)
        {
            await mongoCollection.InsertManyAsync(entityList);
            return entityList;
        }


        #endregion

        #region 更新
        public virtual TEntity Update(TEntity entity)
        {
            mongoCollection.ReplaceOne(x => x.Id == entity.Id, entity);
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await mongoCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
            return entity;
        }

        public virtual bool Update(string id, UpdateDefinition<TEntity> update)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var result = mongoCollection.UpdateOne(filter, update);
            return result.ModifiedCount > 0;
        }

        public virtual async Task<bool> UpdateAsync(string id, UpdateDefinition<TEntity> update)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var result = await mongoCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        public virtual bool Update(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            return mongoCollection.UpdateMany(filter, update).ModifiedCount > 0;
        }

        public virtual async Task<bool> UpdateAsync(FilterDefinition<TEntity> filter, UpdateDefinition<TEntity> update)
        {
            var result = await mongoCollection.UpdateManyAsync(filter, update);
            return result.ModifiedCount > 0;
        }


        #endregion


        #region 删除
        public virtual bool Delete(TEntity entity)
        {
            return mongoCollection.DeleteOne(d => d.Id == entity.Id).DeletedCount > 0;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            var result = await mongoCollection.DeleteOneAsync(d => d.Id == entity.Id);
            return result.DeletedCount > 0;
        }

        public virtual bool Delete(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            return mongoCollection.DeleteOne(filter).DeletedCount > 0;
        }

        public virtual async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            var result = await mongoCollection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }

        public virtual bool Delete(FilterDefinition<TEntity> filter)
        {
            return mongoCollection.DeleteMany(filter).DeletedCount > 0;
        }

        public virtual async Task<bool> DeleteAsync(FilterDefinition<TEntity> filter)
        {
            var result = await mongoCollection.DeleteManyAsync(filter);
            return result.DeletedCount > 0;
        }


        #endregion

        #region 聚合
        public virtual long Count()
        {
            var filter = Builders<TEntity>.Filter.Empty;
            return mongoCollection.Count(filter);
        }

        public virtual Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

        public virtual long Count(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<long> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual long LongCount()
        {
            throw new NotImplementedException();
        }

        public virtual Task<long> LongCountAsync()
        {
            throw new NotImplementedException();
        }

        public virtual long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public virtual Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion

        //public virtual async Task<TE> InsertAsync(TE instance)
        //{
        //    await mongoCollection.InsertOneAsync(instance);
        //    return instance;
        //}

        //public virtual async void Delete(TE instance)
        //{
        //    var filter = Builders<TE>.Filter.Eq("_id", instance.Id);

        //    await mongoCollection.DeleteOneAsync(filter);
        //}

        //public virtual async Task<TE> GetAsync(string id)
        //{
        //    var filter = Builders<TE>.Filter.Eq("_id", id);
        //    var list = await mongoCollection.FindAsync(filter);
        //    return list.SingleOrDefault();
        //}

        //public virtual async Task<IEnumerable<TEntity>> RetrieveAll()
        //{
        //    var filter = Builders<TEntity>.Filter.Empty;
        //    var list = await mongoCollection.FindSync(filter).ToListAsync();
        //    return list;
        //}

        //public virtual async Task<TE> UpdateAsync(TE instance)
        //{
        //    var filter =Builders<TE>.Filter.Eq("_id", instance.Id);
        //    var previousInstance = await mongoCollection.FindOneAndReplaceAsync(filter, instance);
        //    return previousInstance;
        //}
    }
}
