using Microsoft.EntityFrameworkCore;
using WApp.Domain.Models;

namespace WApp.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the ID property to use GUID and auto-generate values
            modelBuilder.Entity<Student>()
                .Property(s => s.ID)
                .HasDefaultValueSql("NEWID()"); // Use NEWID() for SQL Server

            // Configure the Name property
            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}