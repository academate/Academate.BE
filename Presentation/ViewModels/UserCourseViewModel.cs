using System.Collections.Generic;

namespace Presentation.ViewModels
{
    public class UserCourseViewModel
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public double? FinalGrade { get; set; }

        public bool Qualified { get; set; }

        public IEnumerable<SubmittedTaskViewModel> SubmittedTasks { get; set; }

        public int SemesterId { get; set; }

        public IEnumerable<EnrolledExamViewModel> CourseExams { get; set; }
    }
}
