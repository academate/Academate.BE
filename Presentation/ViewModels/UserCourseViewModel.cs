using Presentation.ViewModels;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class UserCourseViewModel
    {
        public int CourseId { get; set; }

        public double? FinalGrade { get; set; }

        public bool Qualified { get; set; }

        public IEnumerable<SubmittedTaskViewModel> SubmittedTasks { get; set; }

        public int SemesterId { get; set; }

        public IEnumerable<EnrolledExamViewModel> CourseExams { get; set; }
    }
}
