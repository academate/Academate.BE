using System;

namespace Domain.Entities
{
    public class SubmittedTask
    {
        public int Id { get; set; }

        public Enrollment Enrollment { get; set; }

        public TaskType TaskType { get; set; }

        public DateTime DateTime { get; set; }

        public double Grade { get; set; }
    }
}