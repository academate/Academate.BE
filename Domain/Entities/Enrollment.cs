using Domain.Enums;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Enrollment : Entity<int>
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int StudentId { get; set; }

        public double? FinalGrade { get; set; }

        public EnrollmentStatus Status { get; set; }

        public bool Qualified { get; set; }

        public IEnumerable<SubmittedTask> SubmittedTasks { get; set; }
    }
}