using Application.Dtos;
using Application.Services.Course;
using AutoMapper;
using Cx.AccessControl.Application.Extensions;
using Microsoft.AspNetCore.Http;
using Repository.Enrollment;
using Repository.Exams;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Enrollment
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IExamRepository _examRepository;
        private readonly ICourseService _courseService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository,
            IExamRepository examRepository,
            ICourseService courseService,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _examRepository = examRepository;
            _courseService = courseService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserCourseDto>> GetEnrolledCourses()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var enrollments = (await _enrollmentRepository.GetEnrollmentsOfUser(userId)).ToArray();

            var enrolledCoursesId = enrollments.Select(e => e.Id);
            var userCourses = (await _courseService.GetCoursesByIds(enrolledCoursesId)).ToArray();

            var userCoursesDto = enrollments.Select(_mapper.Map<UserCourseDto>).ToArray();
            FillCourseExams(userCoursesDto, userCourses);

            return userCoursesDto;
        }

        private static void FillCourseExams(IEnumerable<UserCourseDto> userCoursesDto, CourseDto[] userCourses)
        {
            foreach (var userCourseDto in userCoursesDto)
            {
                var relevantCourse = userCourses.FirstOrDefault(c => c.Id == userCourseDto.CourseId);
                if (relevantCourse == null)
                    continue;

                userCourseDto.Title = relevantCourse.Title;
                userCourseDto.SemesterId = relevantCourse.Semester.Id;
                userCourseDto.CourseExams = relevantCourse.Exams;
            }
        }

        public async Task<IEnumerable<ExamDto>> GetEnrolledExams()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var enrolledCourses = (await _enrollmentRepository.GetEnrollmentsOfUser(userId))
                .Select(e => e.CourseId);

            var exams = (await _examRepository.GetExamsByCourseIds(enrolledCourses));

            var examDtos = exams.Select(_mapper.Map<ExamDto>);
            return examDtos;
        }

        public async Task<IEnumerable<AcademicUnitDto>> GetEnrolledAcademicUnits()
        {
            var userId = _httpContextAccessor.HttpContext.User.GetUserId();
            var enrolledCourses = (await _enrollmentRepository.GetEnrollmentsOfUser(userId))
                .Select(e => e.CourseId).ToArray();

            var courses = (await _courseService.GetCoursesByIds(enrolledCourses)).ToDictionary(c => c.Id);

            var academicUnitsDto = (await _courseService.GetAcademicUnitsByCourseIds(enrolledCourses))
                .Select(_mapper.Map<AcademicUnitDto>).ToArray();

            foreach (var academicUnitDto in academicUnitsDto)
            {
                var semester = courses[academicUnitDto.CourseId].Semester;
                academicUnitDto.SemesterId = semester.Id;
                academicUnitDto.DueTo = semester.EndDate;
            }

            return academicUnitsDto;
        }
    }
}
