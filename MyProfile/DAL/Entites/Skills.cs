using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProfile.DAL.Entites
{
    [Table("Skills")]
    public class Skills
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }
    }
}
