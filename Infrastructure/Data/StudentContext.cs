using Microsoft.EntityFrameworkCore;
using WApp.Domain.Models;
using Stream = WApp.Domain.Models.Stream;

namespace WApp.Infrastructure.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectResult> SubjectResults { get; set; }
        public DbSet<YearlyGpa> YearlyGpas { get; set; }
        public DbSet<Stream> Streams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Student entity
            modelBuilder.Entity<Student>()
                .HasKey(s => s.ID);

            modelBuilder.Entity<Student>()
                .Property(s => s.ID)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsRequired(false)
                .HasMaxLength(50);

            modelBuilder.Entity<Student>()
                .Property(s => s.Gender)
                .IsRequired(false)
                .HasMaxLength(10);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Stream)
                .WithMany(st => st.Students)
                .HasForeignKey(s => s.StreamId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure User entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);

            modelBuilder.Entity<User>()
                .Property(u => u.ID)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(u => u.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            // Configure Result entity
            modelBuilder.Entity<Result>()
                .HasKey(r => new { r.StudentId, r.Year });

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Results)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure Stream entity
            modelBuilder.Entity<Stream>()
                .HasKey(s => s.StreamId);

            modelBuilder.Entity<Stream>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Stream>()
                .HasIndex(s => s.Name)
                .IsUnique();

            // Configure Subject entity
            modelBuilder.Entity<Subject>()
                .HasKey(s => new { s.SubId, s.StreamId });

            modelBuilder.Entity<Subject>()
                .Property(s => s.SubName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Subject>()
                .HasOne(s => s.Stream)
                .WithMany(st => st.Subjects)
                .HasForeignKey(s => s.StreamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Subject>()
                .HasIndex(s => new { s.Year, s.StreamId })
                .HasName("IX_Subject_Year_StreamId");

            // Configure SubjectResult entity
            modelBuilder.Entity<SubjectResult>()
                .HasKey(sr => new { sr.SubId, sr.StreamId, sr.StudentId });

            modelBuilder.Entity<SubjectResult>()
                .Property(sr => sr.MarksObtained)
                .IsRequired();

            modelBuilder.Entity<SubjectResult>()
                .HasOne(sr => sr.Student)
                .WithMany(s => s.SubjectResults)
                .HasForeignKey(sr => sr.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubjectResult>()
                .HasOne(sr => sr.Subject)
                .WithMany(s => s.SubjectResults)
                .HasForeignKey(sr => new { sr.SubId, sr.StreamId })
                .OnDelete(DeleteBehavior.Restrict);

            // Configure YearlyGpa entity
            modelBuilder.Entity<YearlyGpa>()
                .HasKey(y => new { y.StudentId, y.Year });

            modelBuilder.Entity<YearlyGpa>()
                .HasOne(y => y.Student)
                .WithMany(s => s.YearlyGpas)
                .HasForeignKey(y => y.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            SeedMasterData(modelBuilder);
        }

        private void SeedMasterData(ModelBuilder modelBuilder)
        {
            // Seed Streams
            var computerEngineering = new Stream { StreamId = 1, Name = "Computer Engineering" };
            var it = new Stream { StreamId = 2, Name = "IT" };

            modelBuilder.Entity<Stream>().HasData(computerEngineering, it);

            // Seed Subjects for Year 1 (common for both streams)
            var year1Subjects = new[]
            {
                new { SubId = "PHYS", SubName = "Physics", Year = 1 },
                new { SubId = "CHEM", SubName = "Chemistry", Year = 1 },
                new { SubId = "AM", SubName = "Applied Maths", Year = 1 },
                new { SubId = "COMM", SubName = "Communication", Year = 1 },
                new { SubId = "C", SubName = "Logic Building with C", Year = 1 }
            };

            // Add Year 1 subjects for both streams
            foreach (var subject in year1Subjects)
            {
                modelBuilder.Entity<Subject>().HasData(
                    new Subject { SubId = subject.SubId, SubName = subject.SubName, StreamId = 1, Year = subject.Year },
                    new Subject { SubId = subject.SubId, SubName = subject.SubName, StreamId = 2, Year = subject.Year }
                );
            }

            // Seed common Subjects for Year 2
            var commonYear2Subjects = new[]
            {
                new { SubId = "PY", SubName = "Python", Year = 2 },
                new { SubId = "DM", SubName = "Discrete Mathematics", Year = 2 }
            };

            // Add common Year 2 subjects for both streams
            foreach (var subject in commonYear2Subjects)
            {
                modelBuilder.Entity<Subject>().HasData(
                    new Subject { SubId = subject.SubId, SubName = subject.SubName, StreamId = 1, Year = subject.Year },
                    new Subject { SubId = subject.SubId, SubName = subject.SubName, StreamId = 2, Year = subject.Year }
                );
            }

            // Add stream-specific Year 2 subjects for Computer Engineering
            var ceYear2Subjects = new[]
            {
                new { SubId = "DBMS", SubName = "Database Management System", StreamId = 1, Year = 2 },
                new { SubId = "CC", SubName = "Compiler Construction", StreamId = 1, Year = 2 },
                new { SubId = "DS", SubName = "Data Structures", StreamId = 1, Year = 2 }
            };

            foreach (var subject in ceYear2Subjects)
            {
                modelBuilder.Entity<Subject>().HasData(
                    new Subject { SubId = subject.SubId, SubName = subject.SubName, StreamId = subject.StreamId, Year = subject.Year }
                );
            }

            // Add stream-specific Year 2 subjects for IT
            var itYear2Subjects = new[]
            {
                new { SubId = "TOC", SubName = "Theory of Computation", StreamId = 2, Year = 2 },
                new { SubId = "OS", SubName = "Operating System", StreamId = 2, Year = 2 },
                new { SubId = "CA", SubName = "Computer Architecture", StreamId = 2, Year = 2 }
            };

            foreach (var subject in itYear2Subjects)
            {
                modelBuilder.Entity<Subject>().HasData(
                    new Subject { SubId = subject.SubId, SubName = subject.SubName, StreamId = subject.StreamId, Year = subject.Year }
                );
            }
        }
    }
}