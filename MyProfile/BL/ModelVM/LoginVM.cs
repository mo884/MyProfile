using System.ComponentModel.DataAnnotations;

namespace MyProfile.BL.ModelVM
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Requires *")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="Requires *")]
        public string Passward { get; set; }
        public bool RemberMe { get; set; } = true;
    }
}
