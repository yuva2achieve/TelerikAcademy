namespace Supermarket.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
   

    public sealed class Configuration : DbMigrationsConfiguration<SupermarketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SupermarketContext context)
        {
        }
    }
}
