using Application.Dtos;
using Application.Services.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using System.Linq;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly ExamService _examService;

        public ExamsController(ExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var examDtos = _examService.GetExamsOfLoggedInUser();
            var examViewModels = examDtos.Select(Map);

            return Ok(examViewModels);
        }

        private ExamViewModel Map(ExamDto examDto)
        {
            return new ExamViewModel();
        }
    }
}
