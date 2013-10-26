using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMorgue.Models;

namespace AutoMorgue.Data
{
    public class AutoMorgueContext: DbContext
    {
        public AutoMorgueContext()
            :base("AutoMorgueDb")
        { 

        }

        public DbSet<AutoPart> AutoParts { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Morgue> Morgues { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
