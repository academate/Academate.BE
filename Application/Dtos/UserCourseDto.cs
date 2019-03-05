using System.Collections.Generic;

namespace Application.Dtos
{
    public class UserCourseDto
    {
        public int CourseId { get; set; }

        public int EnrollmentId { get; set; }

        public string Title { get; set; }

        public double? FinalGrade { get; set; }

        public bool Qualified { get; set; }

        public int SemesterId { get; set; }

        public IEnumerable<ExamDto> CourseExams { get; set; }
    }
}
