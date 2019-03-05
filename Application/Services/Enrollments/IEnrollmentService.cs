using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Enrollments
{
    public interface IEnrollmentService
    {
        Task<EnrollmentDto> GetEnrollment(int enrollmentId);
        Task<IEnumerable<ExamDto>> GetEnrolledExams();
        Task<IEnumerable<AcademicUnitDto>> GetEnrolledAcademicUnits();
        Task<IEnumerable<UserCourseDto>> GetEnrolledCourses();
    }
}