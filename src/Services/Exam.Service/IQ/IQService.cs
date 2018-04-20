using System;
using System.Collections.Generic;
using System.Text;
using Exam.Models;
using Exam.Repository;
using System.Threading.Tasks;

namespace Exam.Service.IQ
{
    public class IQService : IIQService
    {

        private readonly IEntityRepository<IQEntity> entityRepository;

        public IQService(IEntityRepository<IQEntity> entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        public async Task<IQEntity> Insert(IQEntity iQEntity)
        {
            return await this.entityRepository.InsertAsync(iQEntity);
        }
    }
}
