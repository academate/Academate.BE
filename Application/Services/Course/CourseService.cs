using Application.Dtos;
using Domain.Entities;
using Repository.Course;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesByIds(IEnumerable<int> ids)
        {
            var courses = await _courseRepository.GetByIds(ids);
            var coursesDto = courses.Select(Map);

            return coursesDto;
        }

        private CourseDto Map(Domain.Entities.Course course)
        {
            return new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Points = course.Points,
                Description = course.Description,
                Semester = Map(course.Semester)
            };
        }

        private SemesterDto Map(Semester semester)
        {
            return new SemesterDto
            {
                Id = semester.Id,
                Description = semester.Description,
                StartDate = semester.StartDate,
                EndDate = semester.EndDate
            };
        }
    }
}
