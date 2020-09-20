using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PubSubDemo.Core.Entities;
using System;
using System.Reflection;

namespace PubSubDemo.Data
{
    public class PeopleDbContext : DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> People { get; set; }
    }

     // We need to create this class because entity framework will not automatically discover the DbContext.
     // Entity Framework won't discover because we are not using ASP.NET Directly here
    public class PeopleDbContextFactory : IDesignTimeDbContextFactory<PeopleDbContext>
    {
        public PeopleDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PeopleDbContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING"));

            return new PeopleDbContext(optionsBuilder.Options);
        }
    }
}
