using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
using Ad4You.Models;

namespace Ad4You
{
    public class Ad4YouContext : DbContext
    {
        public DbSet<City> city { get; set; }
        public DbSet<Currency> currency { get; set; }
        public DbSet<Rubric> rubric { get; set; }
        public DbSet<Ad> ad { get; set; }

        public Ad4YouContext(DbContextOptions<Ad4YouContext> options):base(options)
        {

        }
    }

    public class EFDBContextFactory : IDesignTimeDbContextFactory<Ad4YouContext>
    {
        public Ad4YouContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Ad4YouContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Ad4YouDB;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("Ad4You"));

            return new Ad4YouContext(optionsBuilder.Options);
        }
    }
}
