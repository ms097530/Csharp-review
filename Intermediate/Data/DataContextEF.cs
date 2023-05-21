using Intermediate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Intermediate.Data
{
    // giving new class access to everything in DbContext
    // EntityFramework allows you to work with DB and build backend without knowing SQL
    public class DataContextEF : DbContext
    {
        // * added ? and ="" to get rid of warning about possible null reference assignment - differs from provided code
        private IConfiguration _config;
        // set configuration to be the same as passed in configuration
        // * NOW, we are getting connection string without exposing it or data in it to application code
        // ? also avoids repeating code
        // ? may not want devs to have access to connection string
        public DataContextEF(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Computer>? Computer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    _config.GetConnectionString("DefaultConnection"),
                    (options) => options.EnableRetryOnFailure()
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        // map model to actual table in SQL server
        {
            // ? set default schema instead of doing as commented out below
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
            modelBuilder.Entity<Computer>()
            // call this to make it keyless
            // .HasNoKey();
            .HasKey(c => c.ComputerId);
            // name of table, then name of schema
            // i.e. in DB, we have TutorialAppSchema.Computer
            // my default uses DBO (?) schema, so need to specify
            // .ToTable("Computer", "TutorialAppSchema");
            // .ToTable("TableName", "SchemaName");
        }
    }
}