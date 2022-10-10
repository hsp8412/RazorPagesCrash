﻿using System.ComponentModel.DataAnnotations;

namespace RazorPagesCrash.Model
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name ="Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be in range of 1-100!!!")]
        public int DisplayOrder { get; set; }

    }
}
