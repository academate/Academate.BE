namespace Domain.Entities
{
    public class GradeComponent
    {
        public int Id { get; set; }

        public Course Course { get; set; }

        public TaskType TaskType { get; set; }

        public string Description { get; set; }

        public int Percentage { get; set; }
    }
}