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
    }
}
