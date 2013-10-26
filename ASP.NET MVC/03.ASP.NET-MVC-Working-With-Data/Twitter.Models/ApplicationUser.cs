using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Models
{
    public class ApplicationUser : User
    {
        public ApplicationUser()
            : base()
        {
            this.Tweets = new HashSet<Tweet>();
            this.FavoriteTweets = new HashSet<Tweet>();
            this.Followers = new HashSet<ApplicationUser>();
            this.Following = new HashSet<ApplicationUser>();
        }

        public ApplicationUser(string userName)
            : base(userName)
        {
            this.Tweets = new HashSet<Tweet>();
            this.FavoriteTweets = new HashSet<Tweet>();
            this.Followers = new HashSet<ApplicationUser>();
            this.Following = new HashSet<ApplicationUser>();
        }

        public string FullName { get; set; }

        public string ProfilePicture { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }

        public virtual ICollection<Tweet> FavoriteTweets { get; set; }

        public virtual ICollection<ApplicationUser> Followers { get; set; }

        public virtual ICollection<ApplicationUser> Following { get; set; }
    }
}
