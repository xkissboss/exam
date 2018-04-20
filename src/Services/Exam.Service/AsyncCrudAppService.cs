using Exam.Models;
using Exam.Repository;
using Exam.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Service
{
    public abstract class AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey> where TEntity : BaseEntity
        where TEntityDto : IEntityDto<TPrimaryKey>
    {
        protected readonly IEntityRepository<TEntity> entityRepository;
        public AsyncCrudAppService(IEntityRepository<TEntity> entityRepository)
        {
            this.entityRepository = entityRepository;
        }


        public virtual async Task<TEntity> Get(string id)
        {
            var entity = await GetEntityByIdAsync(id);
            return entity;
        }

        //public virtual async Task<PagedResultDto<TEntityDto>> GetAll(TGetAllInput input)
        //{
        //    CheckGetAllPermission();

        //    var query = CreateFilteredQuery(input);

        //    var totalCount = await AsyncQueryableExecuter.CountAsync(query);

        //    query = ApplySorting(query, input);
        //    query = ApplyPaging(query, input);

        //    var entities = await AsyncQueryableExecuter.ToListAsync(query);

        //    return new PagedResultDto<TEntityDto>(
        //        totalCount,
        //        entities.Select(MapToEntityDto).ToList()
        //    );
        //}

        public virtual async Task<TEntity> Create(TEntity input)
        {
            return await entityRepository.InsertAsync(input);
        }

        //public virtual async Task<TEntityDto> Update(TUpdateInput input)
        //{
        //    CheckUpdatePermission();

        //    var entity = await GetEntityByIdAsync(input.Id);

        //    MapToEntity(input, entity);
        //    await CurrentUnitOfWork.SaveChangesAsync();

        //    return MapToEntityDto(entity);
        //}

        //public virtual Task Delete(TDeleteInput input)
        //{
        //    return Repository.DeleteAsync(input.Id);
        //}

        protected virtual Task<TEntity> GetEntityByIdAsync(string id)
        {
            return entityRepository.GetAsync(id);
        }
    }
}
