﻿using System;

namespace Domain.Entities
{
    public class AcademicUnit : Entity<int>
    {
        public Course Course { get; set; }

        public string Title { get; set; }

        public DateTime DateTime { get; set; }

        public int Duration { get; set; }

        public bool Active { get; set; }

        public Person Lecturer { get; set; }

        public string Comment { get; set; }
    }
}