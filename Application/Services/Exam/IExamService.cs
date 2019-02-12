using Application.Dtos;
using System.Collections.Generic;

namespace Application.Services.Exam
{
    public interface IExamService
    {
        IEnumerable<ExamDto> GetExamsOfLoggedInUser();
    }
}