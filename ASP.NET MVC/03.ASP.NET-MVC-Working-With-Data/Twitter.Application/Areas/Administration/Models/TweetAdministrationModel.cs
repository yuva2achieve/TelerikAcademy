using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Twitter.Models;

namespace Twitter.Application.Areas.Administration.Models
{
    public class TweetAdministrationModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }
    }
}