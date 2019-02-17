namespace Application.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Points { get; set; }

        public string Description { get; set; }

        public SemesterDto Semester { get; set; }
    }
}
