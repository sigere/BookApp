
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BookApp.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookApp.Models.DbModels.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    } 
}