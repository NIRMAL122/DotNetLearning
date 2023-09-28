using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Players.Models;

public partial class StudyContext : DbContext
{
    public StudyContext()
    {
    }

    public StudyContext(DbContextOptions<StudyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DotnetQuestion> DotnetQuestions { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeView> EmployeeViews { get; set; }

    public virtual DbSet<Friend> Friends { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Std> Stds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DotnetQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dotnetQu__3213E83FA1C611BB");

            entity.ToTable("dotnetQuestion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DelivDate).HasColumnType("date");
            entity.Property(e => e.PriceDate).HasColumnType("date");
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Emp");

            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.Salary, "IX_Employees_Salary");

            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Dept).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("EMPLOYEE_VIEW");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.Salary).HasColumnName("SALARY");
        });

        modelBuilder.Entity<Friend>(entity =>
        {
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Company)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(6)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Gender");

            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sex");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__logs__3214EC077A3168C4");

            entity.ToTable("logs");

            entity.Property(e => e.Num).HasMaxLength(50);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PLAYERS__3214EC27B1125674");

            entity.ToTable("PLAYERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COUNTRY");
            entity.Property(e => e.HighestScore).HasColumnName("HIGHEST_SCORE");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ROLE");
        });

        modelBuilder.Entity<Std>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Std");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
