using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Enrollment
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<ExamDto>> GetEnrolledExams();
        Task<IEnumerable<AcademicUnitDto>> GetEnrolledAcademicUnits();
        Task<IEnumerable<UserCourseDto>> GetEnrolledCourses();
    }
}