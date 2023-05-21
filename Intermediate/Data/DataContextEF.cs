using Intermediate.Models;
using Microsoft.EntityFrameworkCore;

namespace Intermediate.Data
{
    // giving new class access to everything in DbContext
    // EntityFramework allows you to work with DB and build backend without knowing SQL
    public class DataContextEF : DbContext
    {
        public DbSet<Computer>? Computer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;",
                    (options) => options.EnableRetryOnFailure()
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        // map model to actual table in SQL server
        {
            // ? set default schema instead of doing as commented out below
            modelBuilder.HasDefaultSchema("TutorialAppSchema");
            modelBuilder.Entity<Computer>();
            // name of table, then name of schema
            // i.e. in DB, we have TutorialAppSchema.Computer
            // my default uses DBO (?) schema, so need to specify
            // .ToTable("Computer", "TutorialAppSchema");
            // .ToTable("TableName", "SchemaName");
        }
    }
}