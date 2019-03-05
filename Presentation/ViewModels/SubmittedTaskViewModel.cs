using Domain.Entities;
using System;

namespace Presentation.ViewModels
{
    public class SubmittedTaskViewModel
    {
        public string Title { get; set; }

        public TaskType TaskType { get; set; }

        public DateTime DateTime { get; set; }

        public double Grade { get; set; }
    }
}