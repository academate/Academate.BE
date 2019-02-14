using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Exam
{
    public interface IExamService
    {
        Task<IEnumerable<ExamDto>> GetExamsOfLoggedInUser();
    }
}