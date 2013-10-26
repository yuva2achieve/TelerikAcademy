using System;
using System.Linq;
using StudentSystem.Data;
using StudentSystem.Data.Migrations;
using StudentSystem.Model;
using System.Data.Entity;

namespace StudentSystem.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            var dbContext = new StudentSystemContext();
        }
    }
}
