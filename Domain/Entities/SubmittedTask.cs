using System;

namespace Domain.Entities
{
    public class SubmittedTask : Entity<int>
    {
        public int EnrollmentId { get; set; }

        public Enrollment Enrollment { get; set; }

        public string Title { get; set; }

        public TaskType TaskType { get; set; }

        public DateTime DateTime { get; set; }

        public double Grade { get; set; }
    }
}