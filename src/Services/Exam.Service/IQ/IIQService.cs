using Exam.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Service.IQ
{
    public interface IIQService
    {
        Task<IQEntity> Insert(IQEntity iQEntity);
    }
}
