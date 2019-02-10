using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class ConfigurationViewModel
    {
        [Required]
        public string Key { get; set; }

        public string Value { get; set; }

        public string Group { get; set; }
    }
}
