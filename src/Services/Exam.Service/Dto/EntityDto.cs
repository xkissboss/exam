using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Service.Dto
{
    [Serializable]
    public class EntityDto : EntityDto<string>, IEntityDto
    {
       
        public EntityDto()
        {

        }

        
        public EntityDto(string id)
            : base(id)
        {
        }
    }

    
    [Serializable]
    public class EntityDto<TPrimaryKey> : IEntityDto<TPrimaryKey>
    {
        
        public TPrimaryKey Id { get; set; }

        
        public EntityDto()
        {

        }

        public EntityDto(TPrimaryKey id)
        {
            Id = id;
        }
    }
}
