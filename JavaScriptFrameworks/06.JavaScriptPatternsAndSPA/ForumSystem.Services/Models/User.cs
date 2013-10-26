using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumSystem.Services.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nickname { get; set; }
        public string AuthCode { get; set; }
        public string SessionKey { get; set; }
    }
}