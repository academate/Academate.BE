using System;

namespace Presentation.ViewModels
{
    public class AcademicUnitViewModel
    {
        public int CourseId { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public int Duration { get; set; }

        public string Lecturer { get; set; }

        public bool Repeatable { get; set; }

        public int SemesterId { get; set; }

        public DateTime DueTo { get; set; }

        public string Comment { get; set; }
    }
}
