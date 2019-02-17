using Application.Dtos;
using Application.Services.Enrollment;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System;
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

        public EnrollmentsController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet("/exams")]
        public async Task<IActionResult> GetEnrolledExams()
        {
            var examDtos = await _enrollmentService.GetEnrolledExams();
            var examViewModels = examDtos.Select(Map);

            return Ok(examViewModels);
        }

        [HttpGet("/lessons")]
        public async Task<IActionResult> GetEnrolledAcademicUnits()
        {
            var academicUnitsDto = await _enrollmentService.GetEnrolledAcademicUnits();
            var academicUnitsDtoViewModels = academicUnitsDto.Select(Map);

            return Ok(academicUnitsDtoViewModels);
        }

        private EnrolledExamViewModel Map(ExamDto examDto)
        {
            return new EnrolledExamViewModel
            {
                Id = examDto.Id,
                Title = examDto.Title,
                StartDate = examDto.DateTime,
                Duration = examDto.Duration,
                Type = Enum.GetName(typeof(ExamType), examDto.Type)
            };
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
