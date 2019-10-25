using CommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CommerceApp.DAL
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base("CommerceDbConn")
        {
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTranslate>ProductTranslates { get; set; }

    }
}