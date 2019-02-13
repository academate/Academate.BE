using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Exam : Entity<int>
    {
        public Course Course { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public int Duration { get; set; }

        public ExamType Type { get; set; }
    }
}