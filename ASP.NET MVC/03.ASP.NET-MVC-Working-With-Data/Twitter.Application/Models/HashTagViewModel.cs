using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Twitter.Application.Models
{
    public class HashTagViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TweetsCount { get; set; }
    }
}