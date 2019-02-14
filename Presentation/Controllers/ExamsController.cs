using Application.Dtos;
using Application.Services.Exam;
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
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var examDtos = await _examService.GetExamsOfLoggedInUser();
            var examViewModels = examDtos.Select(Map);

            return Ok(examViewModels);
        }

        private ExamViewModel Map(ExamDto examDto)
        {
            return new ExamViewModel
            {
                Id = examDto.Id,
                Title = examDto.Title,
                StartDate = examDto.DateTime,
                Duration = examDto.Duration,
                Type = Enum.GetName(typeof(ExamType), examDto.Type)
            };
        }
    }
}
