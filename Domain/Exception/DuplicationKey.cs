namespace Domain.Exception
{
    public class DuplicationKey : DomainException
    {
        public DuplicationKey(string message) : base(message)
        {

        }
    }
}
