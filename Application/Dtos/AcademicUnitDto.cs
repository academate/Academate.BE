using Domain.Entities;
using System;

namespace Application.Dtos
{
    public class AcademicUnitDto
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public int Duration { get; set; }

        public bool Active { get; set; }

        public Person Lecturer { get; set; }

        public string Comment { get; set; }
    }
}
