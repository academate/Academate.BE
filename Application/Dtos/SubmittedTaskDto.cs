﻿using Domain.Entities;
using System;

namespace Application.Dtos
{
    public class SubmittedTaskDto
    {
        public string Title { get; set; }

        public TaskType TaskType { get; set; }

        public DateTime DateTime { get; set; }

        public double Grade { get; set; }
    }
}