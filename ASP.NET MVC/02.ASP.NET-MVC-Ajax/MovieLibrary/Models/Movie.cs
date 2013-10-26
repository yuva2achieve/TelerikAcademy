using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieLibrary.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 6)]
        public string Title { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 6)]
        public string Director { get; set; }
        [Required]
        [Range(1900,2020)]
        public int Year { get; set; }
        public virtual Actor LeadMaleActor { get; set; }
        public virtual Actor LeadFemaleActor { get; set; }
    }
}