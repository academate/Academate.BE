using Application.Dtos;
using Cx.AccessControl.Application.Extensions;
using Microsoft.AspNetCore.Http;
using Repository.Enrollment;
using Repository.Exams;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Exam
{
    public class ExamService : IExamService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IExamRepository _examRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExamService(IEnrollmentRepository enrollmentRepository,
            IExamRepository examRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _enrollmentRepository = enrollmentRepository;
            _examRepository = examRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<ExamDto>> GetExamsOfLoggedInUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var enrolledCourses = (await _enrollmentRepository.GetEnrollmentsOfUser(userId))
                .Select(e => e.CourseId);

            var exams = (await _examRepository.GetExamsOfCourses(enrolledCourses));

            var examDtos = exams.Select(Map);
            return examDtos;
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
