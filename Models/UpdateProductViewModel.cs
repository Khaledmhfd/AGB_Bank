﻿using System.ComponentModel.DataAnnotations;

namespace AGB_Bank.Models
{
    public class UpdateProductViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}




