namespace Domain.Entities
{
    public class Room : Entity<int>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}