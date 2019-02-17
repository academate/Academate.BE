using System.Collections.Generic;

namespace Domain.Entities
{
    public class Course : Entity<int>
    {
        public string Title { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public int Points { get; set; }

        public string Description { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }

        public Person Lecturer { get; set; }

        public IEnumerable<Exam> Exams { get; set; }

        public IEnumerable<GradeComponent> GradeComponents { get; set; }

        public IEnumerable<AcademicUnit> AcademicUnits { get; set; }
    }
}
