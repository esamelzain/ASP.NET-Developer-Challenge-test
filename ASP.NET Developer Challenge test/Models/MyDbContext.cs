using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASP.NET_Developer_Challenge_test.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base("MyDbContext")
        {
        }

        public DbSet<Services> Services { get; set; }
        public DbSet<Interrest> Interrest { get; set; }

    }

}