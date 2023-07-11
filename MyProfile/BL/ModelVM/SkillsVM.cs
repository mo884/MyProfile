using System.ComponentModel.DataAnnotations;

namespace MyProfile.BL.ModelVM
{
    public class SkillsVM
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }
        public int Pricent { get; set; }
    }
}
