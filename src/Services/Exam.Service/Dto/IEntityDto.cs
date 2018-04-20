using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Service.Dto
{
    public interface IEntityDto : IEntityDto<string>
    {
    }
    
    public interface IEntityDto<TPrimaryKey>
    {
       
        TPrimaryKey Id { get; set; }
    }
}
