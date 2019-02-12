using Application.Dtos;
using Repository.Enrollment;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services.Exam
{
    public class ExamService : IExamService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public ExamService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public IEnumerable<ExamDto> GetExamsOfLoggedInUser()
        {
            var userId = 1;
            var enrolledCourses = _enrollmentRepository.GetEnrollmentsOfUser(userId)
                .Select(e => e.CourseId);

            var courses = _
        }
    }
}
