using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Review14.Models;

namespace GummyKingdom.Tests.Models 
{
    class TestDbContext : GummyKingdomDbContext
    {
        public override DbSet<Product> Products { get; set; }

        public override DbSet<User> Users { get; set; }

        public override DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=gummykingdom_test;uid=root;pwd=root;");
        }
    }
}
