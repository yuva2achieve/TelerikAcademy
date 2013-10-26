using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieLibrary.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Name { get; set; }
        [Required]
        [Range(5,90)]
        public int Age { get; set; }
    }
}