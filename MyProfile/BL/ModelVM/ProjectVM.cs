using System.ComponentModel.DataAnnotations;

namespace MyProfile.BL.ModelVM
{
    public class ProjectVM
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Href { get; set; }
        public string? Image { get; set; }
        public IFormFile? PathImage { get; set; }
    }
}
