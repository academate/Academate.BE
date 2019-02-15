using Application.Dtos;
using Repository.Exams;

namespace Application.Services.Exam
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;

        public ExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        private ExamDto Map(Domain.Entities.Exam exam)
        {
            return new ExamDto
            {
                Id = exam.Id,
                Title = exam.Title,
                DateTime = exam.DateTime,
                Duration = exam.Duration,
                Type = exam.Type
            };
        }
    }
}
