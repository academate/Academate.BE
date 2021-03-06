﻿using Application.Services.Enrollments;
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnrollment(int id)
        {
            var enrollmentDto = await _enrollmentService.GetEnrollment(id);
            var enrollmentViewModel = _mapper.Map<EnrollmentViewModel>(enrollmentDto);

            return Ok(enrollmentViewModel);
        }

        [HttpGet("courses")]
        public async Task<IActionResult> GetEnrolledCourses()
        {
            var courseDtos = await _enrollmentService.GetEnrolledCourses();
            var examViewModels = courseDtos.Select(_mapper.Map<UserCourseViewModel>);

            return Ok(examViewModels);
        }

        [HttpGet("exams")]
        public async Task<IActionResult> GetEnrolledExams()
        {
            var examDtos = await _enrollmentService.GetEnrolledExams();
            var examViewModels = examDtos.Select(_mapper.Map<EnrolledExamViewModel>);

            return Ok(examViewModels);
        }

        [HttpGet("lessons")]
        public async Task<IActionResult> GetEnrolledAcademicUnits()
        {
            var academicUnitsDto = await _enrollmentService.GetEnrolledAcademicUnits();
            var academicUnitsDtoViewModels = academicUnitsDto.Select(_mapper.Map<AcademicUnitViewModel>);

            return Ok(academicUnitsDtoViewModels);
        }
    }
}
