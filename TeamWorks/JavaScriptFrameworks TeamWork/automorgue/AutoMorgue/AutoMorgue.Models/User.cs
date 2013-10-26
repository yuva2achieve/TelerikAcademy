using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMorgue.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string AuthCode { get; set; }
        public string SessionKey { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public User()
        {
            this.Orders = new HashSet<Order>();
        }
    }
}
