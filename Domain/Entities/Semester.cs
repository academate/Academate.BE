using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Semester : Entity<int>
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}