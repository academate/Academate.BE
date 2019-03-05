using System.Collections.Generic;

namespace Presentation.ViewModels
{
    public class EnrollmentViewModel
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Title { get; set; }

        public double? FinalGrade { get; set; }

        public string Status { get; set; }

        public bool Qualified { get; set; }

        public IEnumerable<SubmittedTaskViewModel> SubmittedTasks { get; set; }
    }
}
