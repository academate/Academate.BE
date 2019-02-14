using Domain.Enums;
using System;

namespace Application.Dtos
{
    public class ExamDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public int Duration { get; set; }

        public ExamType Type { get; set; }
    }
}