﻿using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;

namespace Domain.DbContext
{
    public class AcademateDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AcademateDbContext(DbContextOptions<AcademateDbContext> options)
            : base(options)
        {

        }

        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<AcademicUnit> AcademicUnits { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<GradeComponent> GradeComponents { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<SubmittedTask> SubmittedTasks { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnUserCreating(modelBuilder);
            OnConfigurationCreating(modelBuilder);
            OnSemesterCreating(modelBuilder);
            OnRoomCreating(modelBuilder);
            OnPersonCreating(modelBuilder);
            OnExamCreating(modelBuilder);
            OnCourseCreating(modelBuilder);
            OnAcademicUnitCreating(modelBuilder);
            OnEnrollmentCreating(modelBuilder);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "admin@admin", UserName = "admin", FirstName = "admin", Password = "admin" }
            );

            var exam1 = new Exam
            {
                Id = 1,
                CourseId = 1,
                DateTime = new DateTime(2019, 2, 16, 9, 0, 0),
                Title = "Arabic-Grammar",
                Duration = 120,
                Type = ExamType.TermA
            };
            var exam2 = new Exam
            {
                Id = 2,
                CourseId = 1,
                DateTime = new DateTime(2019, 2, 17, 8, 30, 0),
                Title = "Arabic-General",
                Duration = 60,
                Type = ExamType.TermA
            };
            var exam3 = new Exam
            {
                Id = 3,
                CourseId = 2,
                DateTime = new DateTime(2019, 2, 18, 8, 30, 0),
                Title = "Hebrew-General",
                Duration = 180,
                Type = ExamType.TermA
            };
            modelBuilder.Entity<Exam>().HasData(exam1, exam2, exam3);

            modelBuilder.Entity<AcademicUnit>().HasData(
                new AcademicUnit
                {
                    Id = 1,
                    CourseId = 1,
                    Title = "Arabic Lecture",
                    Active = true,
                    DateTime = new DateTime(2019, 2, 20, 12, 30, 0),
                    Duration = 90,
                    Repeatable = true
                },
                new AcademicUnit
                {
                    Id = 2,
                    CourseId = 1,
                    Title = "Arabic Grammar",
                    Active = true,
                    DateTime = new DateTime(2019, 2, 21, 14, 30, 0),
                    Duration = 90,
                    Repeatable = true
                },
                new AcademicUnit
                {
                    Id = 3,
                    CourseId = 2,
                    Title = "Hebrew Lecture",
                    Active = true,
                    DateTime = new DateTime(2019, 2, 20, 8, 0, 0),
                    Duration = 120,
                    Repeatable = true
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Arabic", Points = 3, SemesterId = 1 },
                new Course { Id = 2, Title = "Hebrew", Points = 2, SemesterId = 1 }
            );

            modelBuilder.Entity<Semester>().HasData(
                new Semester
                {
                    Id = 1,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMonths(3),
                    Description = "Semester A"
                });

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, CourseId = 1, Status = EnrollmentStatus.Active, FinalGrade = 95 },
                new Enrollment { Id = 2, StudentId = 1, CourseId = 2, Status = EnrollmentStatus.Active, FinalGrade = 80 }
            );

            modelBuilder.Entity<SubmittedTask>().HasData(
                new SubmittedTask { Id = 1, Title = "TermA", EnrollmentId = 1, DateTime = DateTime.UtcNow.AddDays(-3), Grade = 100, TaskType = TaskType.Exam },
                new SubmittedTask { Id = 2, Title = "HW 1", EnrollmentId = 1, DateTime = DateTime.UtcNow.AddDays(-5), Grade = 80, TaskType = TaskType.HW },
                new SubmittedTask { Id = 3, Title = "Term B", EnrollmentId = 2, DateTime = DateTime.UtcNow.AddDays(-1), Grade = 90, TaskType = TaskType.Exam },
                new SubmittedTask { Id = 4, Title = "Hw 4", EnrollmentId = 2, DateTime = DateTime.UtcNow.AddDays(-2), Grade = 70, TaskType = TaskType.HW }
                );
        }

        private static void OnUserCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.Email);
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.FirstName).IsRequired();
        }

        private static void OnConfigurationCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>().HasKey(c => c.Key);
            modelBuilder.Entity<Configuration>().HasIndex(c => c.Group);

            modelBuilder.Entity<Configuration>().Property(c => c.Key).HasMaxLength(250);
            modelBuilder.Entity<Configuration>().Property(c => c.Group).HasMaxLength(250);
        }

        private static void OnSemesterCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Semester>().HasKey(s => s.Id);
            modelBuilder.Entity<Semester>()
                .HasMany(s => s.Courses)
                .WithOne(c => c.Semester)
                .HasForeignKey(c => c.SemesterId);

        }

        private static void OnRoomCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasKey(r => r.Id);
            modelBuilder.Entity<Room>().Property(r => r.Title).HasMaxLength(250);
        }

        private static void OnPersonCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.FirstName).HasMaxLength(250);
            modelBuilder.Entity<Person>().Property(p => p.LastName).HasMaxLength(250);
            modelBuilder.Entity<Person>().Ignore(p => p.FullName);
        }

        private static void OnExamCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>().HasKey(e => e.Id);
            modelBuilder.Entity<Exam>().Property(e => e.Title).HasMaxLength(250);
        }

        private static void OnCourseCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasKey(c => c.Id);
            modelBuilder.Entity<Course>().Property(c => c.Title).HasMaxLength(250);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Course>().HasOne(c => c.Lecturer);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Exams)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.GradeComponents)
                .WithOne(g => g.Course);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.AcademicUnits)
                .WithOne(a => a.Course)
                .HasForeignKey(a => a.CourseId);
        }

        private static void OnAcademicUnitCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicUnit>().HasKey(a => a.Id);
            modelBuilder.Entity<AcademicUnit>().
                Property(a => a.Title)
                .HasMaxLength(250);

            modelBuilder.Entity<AcademicUnit>()
                .HasOne(a => a.Lecturer);
        }

        private void OnEnrollmentCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>()
                .HasMany(e => e.SubmittedTasks)
                .WithOne(s => s.Enrollment)
                .HasForeignKey(s => s.EnrollmentId);

        }

    }
}
