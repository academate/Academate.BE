using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.Course
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetCoursesByIds(IEnumerable<int> ids);
        Task<IEnumerable<AcademicUnitDto>> GetAcademicUnitsByCourseIds(IEnumerable<int> ids);
    }
}