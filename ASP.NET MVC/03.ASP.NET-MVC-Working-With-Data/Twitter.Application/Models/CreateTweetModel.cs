using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter.Application.Models
{
    public class CreateTweetModel
    {
        [Required]
        [StringLength(140, MinimumLength=5)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.MultilineText)]
        public string Content { get; set; }
    }
}