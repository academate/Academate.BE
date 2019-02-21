using Application.Dtos;
using Application.Services.Enrollment;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IMapper _mapper;

        public EnrollmentsController(IEnrollmentService enrollmentService,
            IMapper mapper)
        {
            _enrollmentService = enrollmentService;
            _mapper = mapper;
        }

        [HttpGet("/exams")]
        public async Task<IActionResult> GetEnrolledExams()
        {
            var examDtos = await _enrollmentService.GetEnrolledExams();
            var examViewModels = examDtos.Select(_mapper.Map<EnrolledExamViewModel>);

            return Ok(examViewModels);
        }

        [HttpGet("/lessons")]
        public async Task<IActionResult> GetEnrolledAcademicUnits()
        {
            var academicUnitsDto = await _enrollmentService.GetEnrolledAcademicUnits();
            var academicUnitsDtoViewModels = academicUnitsDto.Select(Map);

            return Ok(academicUnitsDtoViewModels);
        }

        private AcademicUnitViewModel Map(AcademicUnitDto academicUnitDto)
        {
            return new AcademicUnitViewModel
            {
                Title = academicUnitDto.Title,
                CourseId = academicUnitDto.CourseId,
                Lecturer = academicUnitDto.Lecturer?.FullName,
                DateTime = academicUnitDto.DateTime,
                Duration = academicUnitDto.Duration,
                Repeatable = academicUnitDto.Repeatable,
                DueTo = academicUnitDto.DueTo,
                SemesterId = academicUnitDto.SemesterId,
                Comment = academicUnitDto.Comment,
            };
        }
    }
}
