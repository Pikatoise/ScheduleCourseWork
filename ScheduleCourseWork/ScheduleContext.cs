using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScheduleCourseWork.Models;

namespace ScheduleCourseWork;

public partial class ScheduleContext : DbContext
{
    public ScheduleContext(string? connectionString)
    {
        this.conn = connectionString;
    }

    public ScheduleContext(DbContextOptions<ScheduleContext> options)
        : base(options)
    {
    }

    private string? conn;

    public virtual DbSet<Cabinet> Cabinets { get; set; }

    public virtual DbSet<Schedulechanged> Schedulechangeds { get; set; }

    public virtual DbSet<Schedulecurrent> Schedulecurrents { get; set; }

    public virtual DbSet<Schedulestandart> Schedulestandarts { get; set; }

    public virtual DbSet<Studygroup> Studygroups { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<Weekday> Weekdays { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(conn);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cabinet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cabinets_pkey");

            entity.ToTable("cabinets");

            entity.HasIndex(e => e.Name, "cabinets_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Schedulechanged>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedulechanged_pkey");

            entity.ToTable("schedulechanged");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cabinet).HasColumnName("cabinet");
            entity.Property(e => e.Schedulecurrent).HasColumnName("schedulecurrent");
            entity.Property(e => e.Studygroup).HasColumnName("studygroup");
            entity.Property(e => e.Sequencenumber).HasColumnName("sequencenumber");
            entity.Property(e => e.Subject).HasColumnName("subject");
            entity.Property(e => e.Division).HasColumnName("division");
            entity.Property(e => e.isremote).HasColumnName("isremote");
            entity.Property(e => e.Teacher).HasColumnName("teacher");

            entity.HasOne(d => d.CabinetNavigation).WithMany(p => p.Schedulechangeds)
                .HasForeignKey(d => d.Cabinet)
                .HasConstraintName("schedulechanged_cabinet_fkey");

            entity.HasOne(d => d.SchedulecurrentNavigation).WithMany(p => p.Schedulechangeds)
                .HasForeignKey(d => d.Schedulecurrent)
                .HasConstraintName("schedulechanged_schedulecurrent_fkey");

            entity.HasOne(d => d.TeacherNavigation).WithMany(p => p.Schedulechangeds)
                .HasForeignKey(d => d.Teacher)
                .HasConstraintName("schedulechanged_teacher_fkey");

            entity.HasOne(d => d.SubjectNavigation).WithMany(p => p.Schedulechangeds)
                .HasForeignKey(d => d.Subject)
                .HasConstraintName("schedulechanged_subject_fkey");

            entity.HasOne(d => d.StudygroupNavigation).WithMany(p => p.Schedulechangeds)
                .HasForeignKey(d => d.Studygroup)
                .HasConstraintName("schedulechanged_studygroup_fkey");
        });

        modelBuilder.Entity<Schedulecurrent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedulecurrents_pkey");

            entity.ToTable("schedulecurrents");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Currentdate).HasColumnName("currentdate");
            entity.Property(e => e.Daytype).HasColumnName("daytype");
            entity.Property(e => e.Weekday).HasColumnName("weekday");

            entity.HasOne(d => d.WeekdayNavigation).WithMany(p => p.Schedulecurrents)
                .HasForeignKey(d => d.Weekday)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("schedulecurrents_weekday_fkey");
        });

        modelBuilder.Entity<Schedulestandart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schedulestandart_pkey");

            entity.ToTable("schedulestandart");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cabinet).HasColumnName("cabinet");
            entity.Property(e => e.Daytype).HasColumnName("daytype");
            entity.Property(e => e.Division).HasColumnName("division");
            entity.Property(e => e.Sequencenumber).HasColumnName("sequencenumber");
            entity.Property(e => e.Studygroup).HasColumnName("studygroup");
            entity.Property(e => e.Subject).HasColumnName("subject");
            entity.Property(e => e.Teacher).HasColumnName("teacher");
            entity.Property(e => e.Weekday).HasColumnName("weekday");

            entity.HasOne(d => d.CabinetNavigation).WithMany(p => p.Schedulestandarts)
                .HasForeignKey(d => d.Cabinet)
                .HasConstraintName("schedulestandart_cabinet_fkey");

            entity.HasOne(d => d.StudygroupNavigation).WithMany(p => p.Schedulestandarts)
                .HasForeignKey(d => d.Studygroup)
                .HasConstraintName("schedulestandart_studygroup_fkey");

            entity.HasOne(d => d.SubjectNavigation).WithMany(p => p.Schedulestandarts)
                .HasForeignKey(d => d.Subject)
                .HasConstraintName("schedulestandart_subject_fkey");

            entity.HasOne(d => d.TeacherNavigation).WithMany(p => p.Schedulestandarts)
                .HasForeignKey(d => d.Teacher)
                .HasConstraintName("schedulestandart_teacher_fkey");

            entity.HasOne(d => d.WeekdayNavigation).WithMany(p => p.Schedulestandarts)
                .HasForeignKey(d => d.Weekday)
                .HasConstraintName("schedulestandart_weekday_fkey");
        });

        modelBuilder.Entity<Studygroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("studygroups_pkey");

            entity.ToTable("studygroups");

            entity.HasIndex(e => e.Name, "studygroups_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("subjects_pkey");

            entity.ToTable("subjects");

            entity.HasIndex(e => e.Name, "subjects_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teachers_pkey");

            entity.ToTable("teachers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Firstname).HasColumnName("firstname");
            entity.Property(e => e.Lastname).HasColumnName("lastname");
            entity.Property(e => e.Surname).HasColumnName("surname");
        });

        modelBuilder.Entity<Weekday>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("weekdays_pkey");

            entity.ToTable("weekdays");

            entity.HasIndex(e => e.Name, "weekdays_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
