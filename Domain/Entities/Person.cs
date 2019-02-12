namespace Domain.Entities
{
    public class Person : Entity<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => string.Join(", ", FirstName, LastName);
    }
}