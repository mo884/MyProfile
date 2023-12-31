﻿using System.ComponentModel.DataAnnotations;

namespace MyProfile.DAL.Entites
{
    public class ProfileEngineer
    {
        [Key]
        public int ID { get; set; }
        public string FullName { get; set; }

        public string? Image { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNummber { get; set; }
        public string? FaceBook { get; set; }
        public string? LinkedIn { get; set; }
        public string? GitHub { get; set; }
        public string? Adress { get; set; }
        public string? Birthday { get; set; }
        public bool Freelance { get; set; }


    }
}
