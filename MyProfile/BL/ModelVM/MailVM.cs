using System.ComponentModel.DataAnnotations;

namespace MyProfile.BL.ModelVM
{
    public class MailVM
    {
        [Required(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Message Required")]

        public string Message { get; set; }
    }
}

