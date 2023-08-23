using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CourseManagement.Models
{
    public partial class CourseManagementContext : DbContext
    {
        public CourseManagementContext()
        {
        }

        public CourseManagementContext(DbContextOptions<CourseManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentInCourse> StudentInCourses { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Slot> Slots { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-JIC1EV75;Database=CourseManagement;User ID=mquan; password=wuandmSE150021@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.SessionId)
                    .HasConstraintName("fk_attendance_session_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("fk_attendance_student_id");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("fk_semester_teacher_id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("fk_course_Subject_id");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("fk_course_teacher_id");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.MajorName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.RoomNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.SemesterName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("fk_session_course_id");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("fk_session_room_id");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("fk_session_teacher_id");

                entity.HasOne(d => d.Slot)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.SlotId)
                    .HasConstraintName("fk_session_slot_id");
            });
            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot");
            });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Email)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.MajorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_student_major_id");
            });

            modelBuilder.Entity<StudentInCourse>(entity =>
            {
                entity.ToTable("StudentInCourse");


                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentInCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("fk_student_in_course_course_id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentInCourses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("fk_student_in_course_student_id");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("fk_subject_major_id");

               
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");

                entity.Property(e => e.Email)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.Property(e => e.TeacherName)
                    .HasMaxLength(225)
                    .IsUnicode(false);

                entity.HasOne(d => d.Major)
                   .WithMany(p => p.Teachers)
                   .HasForeignKey(d => d.MajorId)
                   .HasConstraintName("fk_teacher_major_id");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");
                entity.Property(e => e.Email)
                      .HasMaxLength(255)
                      .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
