using Domain.Enums;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class EnrollmentDto
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Title { get; set; }

        public double? FinalGrade { get; set; }

        public EnrollmentStatus Status { get; set; }

        public bool Qualified { get; set; }

        public IEnumerable<SubmittedTaskDto> SubmittedTasks { get; set; }
    }
}
