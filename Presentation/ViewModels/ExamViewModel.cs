using System;

namespace Presentation.ViewModels
{
    public class ExamViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDate { get; set; }

        public int Duration { get; set; }

        public string Type { get; set; }
    }
}
