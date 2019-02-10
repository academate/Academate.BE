namespace Domain.ValueObjects
{
    public class Configuration
    {
        //[Required]
        //[Key]
        //[StringLength(50)]
        public string Key { get; set; }

        public string Value { get; set; }

        //[StringLength(250)]
        //[Index]
        public string Group { get; set; }
    }
}
