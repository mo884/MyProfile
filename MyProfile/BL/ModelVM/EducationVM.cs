﻿using System.ComponentModel.DataAnnotations;

namespace MyProfile.BL.ModelVM
{
    public class EducationVM
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Start { get; set; }
        public DateTime? FinalTime { get; set; }
    }
}
