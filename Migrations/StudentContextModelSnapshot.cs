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

            modelBuilder.Entity("WApp.Domain.Models.Result", b =>
                {
                    b.Property<Guid>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("PassFail")
                        .HasColumnType("bit");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<double>("TotalMarksObtained")
                        .HasColumnType("float");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ResultId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("StudentId", "SubjectId", "Year");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("WApp.Domain.Models.Stream", b =>
                {
                    b.Property<int>("StreamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StreamId"));

                    b.Property<string>("StreamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StreamId");

                    b.HasIndex("StreamName");

                    b.ToTable("Streams");
                });

            modelBuilder.Entity("WApp.Domain.Models.StreamSubject", b =>
                {
                    b.Property<int>("StreamId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("StreamId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StreamSubjects");
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

                    b.Property<double>("Gpa")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Sid")
                        .HasColumnType("int");

                    b.Property<string>("Stream")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("Sid");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WApp.Domain.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SubjectId");

                    b.HasIndex("Year");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("WApp.Domain.Models.SubjectResult", b =>
                {
                    b.Property<Guid>("SubjectResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<double>("MarksObtained")
                        .HasColumnType("float");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("SubjectResultId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("StudentId", "Year");

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
                    b.Property<Guid>("YearlyGPAId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("YearlyGPAId");

                    b.HasIndex("StudentId", "Year")
                        .IsUnique();

                    b.ToTable("YearlyGpas");
                });

            modelBuilder.Entity("WApp.Domain.Models.Result", b =>
                {
                    b.HasOne("WApp.Domain.Models.Student", "Student")
                        .WithMany("Results")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WApp.Domain.Models.Subject", "Subject")
                        .WithMany("Results")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("WApp.Domain.Models.StreamSubject", b =>
                {
                    b.HasOne("WApp.Domain.Models.Stream", "Stream")
                        .WithMany("StreamSubjects")
                        .HasForeignKey("StreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WApp.Domain.Models.Subject", "Subject")
                        .WithMany("StreamSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stream");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("WApp.Domain.Models.SubjectResult", b =>
                {
                    b.HasOne("WApp.Domain.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WApp.Domain.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("WApp.Domain.Models.YearlyGpa", b =>
                {
                    b.HasOne("WApp.Domain.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WApp.Domain.Models.Stream", b =>
                {
                    b.Navigation("StreamSubjects");
                });

            modelBuilder.Entity("WApp.Domain.Models.Student", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("WApp.Domain.Models.Subject", b =>
                {
                    b.Navigation("Results");

                    b.Navigation("StreamSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
