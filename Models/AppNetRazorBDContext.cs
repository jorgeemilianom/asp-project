using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Curso_ASP.Models
{
    public partial class AppNetRazorBDContext : DbContext
    {
        public AppNetRazorBDContext()
        {
        }

        public AppNetRazorBDContext(DbContextOptions<AppNetRazorBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Beerr> Beerrs { get; set; } = null!;
        public virtual DbSet<Brandd> Brandds { get; set; } = null!;
        public virtual DbSet<Curso> Cursos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB; Database=AppNetRazorBD; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Beerr>(entity =>
            {
                entity.HasKey(e => e.BeerId);

                entity.ToTable("Beerr");

                entity.Property(e => e.BeerId)
                    .ValueGeneratedNever()
                    .HasColumnName("beerId");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Beerrs)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Beerr_Brandd");
            });

            modelBuilder.Entity<Brandd>(entity =>
            {
                entity.HasKey(e => e.BrandId);

                entity.ToTable("Brandd");

                entity.Property(e => e.BrandId)
                    .ValueGeneratedNever()
                    .HasColumnName("brandId");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
