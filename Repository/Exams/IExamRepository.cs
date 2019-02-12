using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Exams
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetExamsByIds(IEnumerable<int> ids);
    }
}