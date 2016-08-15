using System.ComponentModel.DataAnnotations;

namespace Gds.VideoFrontend.Models
{
    public class IdentityUserModel
    {
        public string Type { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Id { get; set; }

        public string Token { get; set; }
    }
}