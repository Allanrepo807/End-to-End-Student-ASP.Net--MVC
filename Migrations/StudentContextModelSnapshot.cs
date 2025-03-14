﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WApp.Infrastructure.Data;

#nullable disable

namespace WApp.Migrations
{
    [DbContext(typeof(StudentContext))]
    partial class StudentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Result", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<int?>("SubjectStreamId")
                        .HasColumnType("int");

                    b.Property<string>("SubjectSubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("TotalMarksObtained")
                        .HasColumnType("float");

                    b.HasKey("StudentId", "Year");

                    b.HasIndex("SubjectSubId", "SubjectStreamId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("WApp.Domain.Models.Stream", b =>
                {
                    b.Property<int>("StreamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StreamId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StreamId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Streams");

                    b.HasData(
                        new
                        {
                            StreamId = 1,
                            Name = "Computer Engineering"
                        },
                        new
                        {
                            StreamId = 2,
                            Name = "IT"
                        });
                });

            modelBuilder.Entity("WApp.Domain.Models.Student", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StreamId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("StreamId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WApp.Domain.Models.Subject", b =>
                {
                    b.Property<string>("SubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StreamId")
                        .HasColumnType("int");

                    b.Property<string>("SubName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SubId", "StreamId");

                    b.HasIndex("StreamId");

                    b.HasIndex("Year", "StreamId")
                        .HasDatabaseName("IX_Subject_Year_StreamId");

                    b.ToTable("Subjects");

                    b.HasData(
                        new
                        {
                            SubId = "PHYS",
                            StreamId = 1,
                            SubName = "Physics",
                            Year = 1
                        },
                        new
                        {
                            SubId = "PHYS",
                            StreamId = 2,
                            SubName = "Physics",
                            Year = 1
                        },
                        new
                        {
                            SubId = "CHEM",
                            StreamId = 1,
                            SubName = "Chemistry",
                            Year = 1
                        },
                        new
                        {
                            SubId = "CHEM",
                            StreamId = 2,
                            SubName = "Chemistry",
                            Year = 1
                        },
                        new
                        {
                            SubId = "AM",
                            StreamId = 1,
                            SubName = "Applied Maths",
                            Year = 1
                        },
                        new
                        {
                            SubId = "AM",
                            StreamId = 2,
                            SubName = "Applied Maths",
                            Year = 1
                        },
                        new
                        {
                            SubId = "COMM",
                            StreamId = 1,
                            SubName = "Communication",
                            Year = 1
                        },
                        new
                        {
                            SubId = "COMM",
                            StreamId = 2,
                            SubName = "Communication",
                            Year = 1
                        },
                        new
                        {
                            SubId = "C",
                            StreamId = 1,
                            SubName = "Logic Building with C",
                            Year = 1
                        },
                        new
                        {
                            SubId = "C",
                            StreamId = 2,
                            SubName = "Logic Building with C",
                            Year = 1
                        },
                        new
                        {
                            SubId = "PY",
                            StreamId = 1,
                            SubName = "Python",
                            Year = 2
                        },
                        new
                        {
                            SubId = "PY",
                            StreamId = 2,
                            SubName = "Python",
                            Year = 2
                        },
                        new
                        {
                            SubId = "DM",
                            StreamId = 1,
                            SubName = "Discrete Mathematics",
                            Year = 2
                        },
                        new
                        {
                            SubId = "DM",
                            StreamId = 2,
                            SubName = "Discrete Mathematics",
                            Year = 2
                        },
                        new
                        {
                            SubId = "DBMS",
                            StreamId = 1,
                            SubName = "Database Management System",
                            Year = 2
                        },
                        new
                        {
                            SubId = "CC",
                            StreamId = 1,
                            SubName = "Compiler Construction",
                            Year = 2
                        },
                        new
                        {
                            SubId = "DS",
                            StreamId = 1,
                            SubName = "Data Structures",
                            Year = 2
                        },
                        new
                        {
                            SubId = "TOC",
                            StreamId = 2,
                            SubName = "Theory of Computation",
                            Year = 2
                        },
                        new
                        {
                            SubId = "OS",
                            StreamId = 2,
                            SubName = "Operating System",
                            Year = 2
                        },
                        new
                        {
                            SubId = "CA",
                            StreamId = 2,
                            SubName = "Computer Architecture",
                            Year = 2
                        });
                });

            modelBuilder.Entity("WApp.Domain.Models.SubjectResult", b =>
                {
                    b.Property<string>("SubId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StreamId")
                        .HasColumnType("int");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("MarksObtained")
                        .HasColumnType("float");

                    b.HasKey("SubId", "StreamId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("SubjectResults");
                });

            modelBuilder.Entity("WApp.Domain.Models.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WApp.Domain.Models.YearlyGpa", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<double>("YGpa")
                        .HasColumnType("float");

                    b.HasKey("StudentId", "Year");

                    b.ToTable("YearlyGpas");
                });

            modelBuilder.Entity("Result", b =>
                {
                    b.HasOne("WApp.Domain.Models.Student", "Student")
                        .WithMany("Results")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WApp.Domain.Models.Subject", null)
                        .WithMany("Results")
                        .HasForeignKey("SubjectSubId", "SubjectStreamId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WApp.Domain.Models.Student", b =>
                {
                    b.HasOne("WApp.Domain.Models.Stream", "Stream")
                        .WithMany("Students")
                        .HasForeignKey("StreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stream");
                });

            modelBuilder.Entity("WApp.Domain.Models.Subject", b =>
                {
                    b.HasOne("WApp.Domain.Models.Stream", "Stream")
                        .WithMany("Subjects")
                        .HasForeignKey("StreamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Stream");
                });

            modelBuilder.Entity("WApp.Domain.Models.SubjectResult", b =>
                {
                    b.HasOne("WApp.Domain.Models.Student", "Student")
                        .WithMany("SubjectResults")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WApp.Domain.Models.Subject", "Subject")
                        .WithMany("SubjectResults")
                        .HasForeignKey("SubId", "StreamId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("WApp.Domain.Models.YearlyGpa", b =>
                {
                    b.HasOne("WApp.Domain.Models.Student", "Student")
                        .WithMany("YearlyGpas")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WApp.Domain.Models.Stream", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("WApp.Domain.Models.Student", b =>
                {
                    b.Navigation("Results");

                    b.Navigation("SubjectResults");

                    b.Navigation("YearlyGpas");
                });

            modelBuilder.Entity("WApp.Domain.Models.Subject", b =>
                {
                    b.Navigation("Results");

                    b.Navigation("SubjectResults");
                });
#pragma warning restore 612, 618
        }
    }
}
