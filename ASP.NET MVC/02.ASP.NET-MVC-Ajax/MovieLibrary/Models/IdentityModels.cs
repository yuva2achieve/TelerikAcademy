using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MovieLibrary.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {
        public ApplicationUser(string userName)
        {
            this.UserName = userName;
        }
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
    }
}