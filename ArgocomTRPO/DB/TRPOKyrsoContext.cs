using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ArgocomTRPO.DB
{
    public partial class TRPOKyrsoContext : DbContext
    {
        public TRPOKyrsoContext()
        {
        }

        public TRPOKyrsoContext(DbContextOptions<TRPOKyrsoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Breaking> Breakings { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Mending> Mendings { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Technology> Technologies { get; set; } = null!;
        public virtual DbSet<Typebreaking> Typebreakings { get; set; } = null!;
        public virtual DbSet<Typetechnology> Typetechnologies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TRPOKyrso;Username=postgres;Password=89521570545");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breaking>(entity =>
            {
                entity.HasKey(e => e.Idbreaking)
                    .HasName("breaking_pkey");

                entity.ToTable("breaking");

                entity.Property(e => e.Idbreaking)
                    .HasColumnName("idbreaking")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Datebreaking).HasColumnName("datebreaking");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Fktechnology).HasColumnName("fktechnology");

                entity.Property(e => e.Fktypebreaking).HasColumnName("fktypebreaking");

                entity.HasOne(d => d.FktechnologyNavigation)
                    .WithMany(p => p.Breakings)
                    .HasForeignKey(d => d.Fktechnology)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("breaking_fktechnology_fkey");

                entity.HasOne(d => d.FktypebreakingNavigation)
                    .WithMany(p => p.Breakings)
                    .HasForeignKey(d => d.Fktypebreaking)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("breaking_fktypebreaking_fkey");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Iddepartment)
                    .HasName("department_pkey");

                entity.ToTable("department");

                entity.Property(e => e.Iddepartment)
                    .HasColumnName("iddepartment")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Namedepartment).HasColumnName("namedepartment");

                entity.Property(e => e.Numberdepartment)
                    .HasMaxLength(5)
                    .HasColumnName("numberdepartment");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Idemployees)
                    .HasName("employees_pkey");

                entity.ToTable("employees");

                entity.Property(e => e.Idemployees)
                    .HasColumnName("idemployees")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Fkspeciality).HasColumnName("fkspeciality");

                entity.Property(e => e.Login)
                    .HasMaxLength(20)
                    .HasColumnName("login");

                entity.Property(e => e.Nameemployee)
                    .HasMaxLength(50)
                    .HasColumnName("nameemployee");

                entity.Property(e => e.Passwordemployee)
                    .HasMaxLength(20)
                    .HasColumnName("passwordemployee");

                entity.Property(e => e.Patronymicemployee)
                    .HasMaxLength(50)
                    .HasColumnName("patronymicemployee");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Surnameemployee)
                    .HasMaxLength(50)
                    .HasColumnName("surnameemployee");

                entity.HasOne(d => d.FkspecialityNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Fkspeciality)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("employees_fkspeciality_fkey");
            });

            modelBuilder.Entity<Mending>(entity =>
            {
                entity.HasKey(e => e.Idmending)
                    .HasName("mending_pkey");

                entity.ToTable("mending");

                entity.Property(e => e.Idmending)
                    .HasColumnName("idbreaking")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Datemending).HasColumnName("datemending");

                entity.Property(e => e.Fkbreaking).HasColumnName("fkbreaking");

                entity.Property(e => e.Fkdepartment).HasColumnName("fkdepartment");

                entity.Property(e => e.Fkemployees).HasColumnName("fkemployees");

                entity.HasOne(d => d.FkbreakingNavigation)
                    .WithMany(p => p.Mendings)
                    .HasForeignKey(d => d.Fkbreaking)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mending_fkbreaking_fkey");

                entity.HasOne(d => d.FkdepartmentNavigation)
                    .WithMany(p => p.Mendings)
                    .HasForeignKey(d => d.Fkdepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mending_fkdepartment_fkey");

                entity.HasOne(d => d.FkemployeesNavigation)
                    .WithMany(p => p.Mendings)
                    .HasForeignKey(d => d.Fkemployees)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mending_fkemployees_fkey");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(e => e.Idspeciality)
                    .HasName("speciality_pkey");

                entity.ToTable("speciality");

                entity.Property(e => e.Idspeciality)
                    .HasColumnName("idspeciality")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Speciality1)
                    .HasMaxLength(50)
                    .HasColumnName("speciality");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Idstatus)
                    .HasName("status_pkey");

                entity.ToTable("status");

                entity.Property(e => e.Idstatus)
                    .HasColumnName("idstatus")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Status1)
                    .HasMaxLength(50)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.HasKey(e => e.Idtechnology)
                    .HasName("technology_pkey");

                entity.ToTable("technology");

                entity.HasIndex(e => e.Uniquecode, "technology_uniquecode_key")
                    .IsUnique();

                entity.Property(e => e.Idtechnology)
                    .HasColumnName("idtechnology")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Fkdepartment).HasColumnName("fkdepartment");

                entity.Property(e => e.Fkstatus).HasColumnName("fkstatus");

                entity.Property(e => e.Fktypetechnology).HasColumnName("fktypetechnology");

                entity.Property(e => e.Uniquecode).HasColumnName("uniquecode");

                entity.HasOne(d => d.FkdepartmentNavigation)
                    .WithMany(p => p.Technologies)
                    .HasForeignKey(d => d.Fkdepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("technology_fkdepartment_fkey");

                entity.HasOne(d => d.FkstatusNavigation)
                    .WithMany(p => p.Technologies)
                    .HasForeignKey(d => d.Fkstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("technology_fkstatus_fkey");

                entity.HasOne(d => d.FktypetechnologyNavigation)
                    .WithMany(p => p.Technologies)
                    .HasForeignKey(d => d.Fktypetechnology)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("technology_fktypetechnology_fkey");
            });

            modelBuilder.Entity<Typebreaking>(entity =>
            {
                entity.HasKey(e => e.Idtypebreaking)
                    .HasName("typebreaking_pkey");

                entity.ToTable("typebreaking");

                entity.Property(e => e.Idtypebreaking)
                    .HasColumnName("idtypebreaking")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Typebreaking1)
                    .HasMaxLength(50)
                    .HasColumnName("typebreaking");
            });

            modelBuilder.Entity<Typetechnology>(entity =>
            {
                entity.HasKey(e => e.Idtypetechnology)
                    .HasName("typetechnology_pkey");

                entity.ToTable("typetechnology");

                entity.Property(e => e.Idtypetechnology)
                    .HasColumnName("idtypetechnology")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Typetechnology1)
                    .HasMaxLength(50)
                    .HasColumnName("typetechnology");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
