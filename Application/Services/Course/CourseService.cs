using Application.Dtos;
using AutoMapper;
using Repository.Course;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository,
            IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> GetCoursesByIds(IEnumerable<int> ids)
        {
            var courses = await _courseRepository.GetByIds(ids);
            var coursesDto = courses.Select(_mapper.Map<CourseDto>);

            return coursesDto;
        }

        public async Task<IEnumerable<AcademicUnitDto>> GetAcademicUnitsByCourseIds(IEnumerable<int> ids)
        {
            var academicUnits = await _courseRepository.GetAcademicUnitsByCourseIds(ids);
            var academicUnitsDto = academicUnits.Select(_mapper.Map<AcademicUnitDto>);

            return academicUnitsDto;
        }
    }
}
