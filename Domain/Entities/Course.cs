using System.Collections.Generic;

namespace Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Semester Semester { get; set; }

        public int Points { get; set; }

        public string Description { get; set; }

        public Room Room { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }

        public Person Lecturer { get; set; }

        public IEnumerable<Exam> Exams { get; set; }

        public IEnumerable<GradeComponent> GradeComponents { get; set; }

        public IEnumerable<AcademicUnit> AcademicUnits { get; set; }
    }
}
