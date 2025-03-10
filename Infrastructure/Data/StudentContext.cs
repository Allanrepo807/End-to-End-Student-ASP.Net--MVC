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
        public DbSet<StreamSubject> StreamSubjects { get; set; }

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
                .Property(s => s.Stream)
                .IsRequired()
                .HasMaxLength(50);

            // Link Student to Stream through Sid
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Sid);

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

            // Configure Result Entity
            modelBuilder.Entity<Result>()
                .HasKey(r => r.ResultId);

            modelBuilder.Entity<Result>()
                .Property(r => r.ResultId)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Student)
                .WithMany(s => s.Results)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Result>()
                .HasOne(r => r.Subject)
                .WithMany(s => s.Results)
                .HasForeignKey(r => r.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            // Create composite index on Result for StudentId and SubjectId
            modelBuilder.Entity<Result>()
                .HasIndex(r => new { r.StudentId, r.SubjectId, r.Year });

            // Configure Stream Entity
            modelBuilder.Entity<Stream>()
                .HasKey(s => s.StreamId);

            modelBuilder.Entity<Stream>()
                .Property(s => s.StreamName)
                .IsRequired()
                .HasMaxLength(50);

            // Create an index on Stream's StreamName for faster lookups
            modelBuilder.Entity<Stream>()
                .HasIndex(s => s.StreamName);

            // Configure Subject Entity
            modelBuilder.Entity<Subject>()
                .HasKey(s => s.SubjectId);

            modelBuilder.Entity<Subject>()
                .Property(s => s.SubjectName)
                .IsRequired()
                .HasMaxLength(100);

            // Create index on Subject for Year
            modelBuilder.Entity<Subject>()
                .HasIndex(s => s.Year);

            // Configure StreamSubject Entity (Many-to-Many relationship)
            modelBuilder.Entity<StreamSubject>()
                .HasKey(ss => new { ss.StreamId, ss.SubjectId });

            modelBuilder.Entity<StreamSubject>()
                .HasOne(ss => ss.Stream)
                .WithMany(s => s.StreamSubjects)
                .HasForeignKey(ss => ss.StreamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StreamSubject>()
                .HasOne(ss => ss.Subject)
                .WithMany(s => s.StreamSubjects)
                .HasForeignKey(ss => ss.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure SubjectResult Entity
            modelBuilder.Entity<SubjectResult>()
                .HasKey(sr => sr.SubjectResultId);

            modelBuilder.Entity<SubjectResult>()
                .Property(sr => sr.SubjectResultId)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<SubjectResult>()
                .HasOne(sr => sr.Student)
                .WithMany()
                .HasForeignKey(sr => sr.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SubjectResult>()
                .HasOne(sr => sr.Subject)
                .WithMany()
                .HasForeignKey(sr => sr.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            // Create composite index on SubjectResult for StudentId and Year
            modelBuilder.Entity<SubjectResult>()
                .HasIndex(sr => new { sr.StudentId, sr.Year });

            // Configure YearlyGpa Entity
            modelBuilder.Entity<YearlyGpa>()
                .HasKey(y => y.YearlyGPAId);

            modelBuilder.Entity<YearlyGpa>()
                .Property(y => y.YearlyGPAId)
                .HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<YearlyGpa>()
                .HasOne(y => y.Student)
                .WithMany()
                .HasForeignKey(y => y.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Create composite index on YearlyGpa for StudentId and Year
            modelBuilder.Entity<YearlyGpa>()
                .HasIndex(y => new { y.StudentId, y.Year })
                .IsUnique(); // A student can only have one GPA per year
        }
    }
}