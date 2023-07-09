using System.ComponentModel.DataAnnotations;

namespace MyProfile.DAL.Entites
{
    public class Projects
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Href { get; set; }
        public string? Image { get; set; }
    }
}
