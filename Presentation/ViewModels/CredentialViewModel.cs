using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class CredentialViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}