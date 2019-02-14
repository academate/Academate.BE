using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Exams
{
    public interface IExamRepository
    {
        Task<IEnumerable<Exam>> GetExamsByCourseIds(IEnumerable<int> courseIds);
    }
}