using Application.Dtos;
using Cx.AccessControl.Application.Extensions;
using Microsoft.AspNetCore.Http;
using Repository.Course;
using Repository.Enrollment;
using Repository.Exams;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Enrollment
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IExamRepository _examRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository,
            IExamRepository examRepository,
            ICourseRepository courseRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _enrollmentRepository = enrollmentRepository;
            _examRepository = examRepository;
            _courseRepository = courseRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<ExamDto>> GetEnrolledExams()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var enrolledCourses = (await _enrollmentRepository.GetEnrollmentsOfUser(userId))
                .Select(e => e.CourseId);

            var exams = (await _examRepository.GetExamsByCourseIds(enrolledCourses));

            var examDtos = exams.Select(Map);
            return examDtos;
        }

        public async Task<IEnumerable<AcademicUnitDto>> GetEnrolledAcademicUnits()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var enrolledCourses = (await _enrollmentRepository.GetEnrollmentsOfUser(userId))
                .Select(e => e.CourseId);

            var academicUnits = (await _courseRepository.GetAcademicUnitsByCourseIds(enrolledCourses));

            var academicUnitsDto = academicUnits.Select(Map);
            return academicUnitsDto;
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

        private AcademicUnitDto Map(Domain.Entities.AcademicUnit academicUnit)
        {
            return new AcademicUnitDto
            {
                CourseId = academicUnit.CourseId,
                Title = academicUnit.Title,
                DateTime = academicUnit.DateTime,
                Duration = academicUnit.Duration,
                Lecturer = academicUnit.Lecturer,
                Comment = academicUnit.Comment
            };
        }
    }
}
