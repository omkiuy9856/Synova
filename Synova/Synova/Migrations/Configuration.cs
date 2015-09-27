namespace Synova.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Synova.DAL.SynovaDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Synova.DAL.SynovaDBContext";
        }

        protected override void Seed(Synova.DAL.SynovaDBContext context)
        {
            var customer = new List<Customer>
            {
                new Customer {Name = "A", Address = "Chemistry",      Tel = 3, },
                new Customer {Name = "B", Address = "Microeconomics", Tel = 4, },
                new Customer {Name = "C", Address = "Macroeconomicsxx", Tel = 5, }
            };
            customer.ForEach(s => context.Customers.AddOrUpdate(p => p.Address, s));
            context.SaveChanges();
        }
    }
}
