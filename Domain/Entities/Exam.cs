using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Exam
    {
        public int Id { get; set; }

        public Course Course { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public Room Room { get; set; }

        public int Duration { get; set; }

        public ExamType Type { get; set; }
    }
}