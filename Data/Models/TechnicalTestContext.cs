using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.Models
{
    public partial class TechnicalTestContext : DbContext
    {
        public TechnicalTestContext()
        {
        }

        public TechnicalTestContext(DbContextOptions<TechnicalTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bar> Bars { get; set; }
        public virtual DbSet<Beer> Beers { get; set; }
        public virtual DbSet<Brewery> Breweries { get; set; }
        public virtual DbSet<Mapping_Bar_Beer> Mapping_Bar_Beers { get; set; }
        public virtual DbSet<Mapping_Brewery_Beer> Mapping_Brewery_Beers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=TechnicalTest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bar>(entity =>
            {
                entity.ToTable("Bar");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Beer>(entity =>
            {
                entity.ToTable("Beer");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Brewery>(entity =>
            {
                entity.ToTable("Brewery");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Mapping_Bar_Beer>(entity =>
            {
                entity.HasOne(d => d.Bar)
                    .WithMany(p => p.Mapping_Bar_Beers)
                    .HasForeignKey(d => d.BarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mapping_Bar_Beers_Bar");

                entity.HasOne(d => d.Beer)
                    .WithMany(p => p.Mapping_Bar_Beers)
                    .HasForeignKey(d => d.BeerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mapping_Bar_Beers_Beer");
            });

            modelBuilder.Entity<Mapping_Brewery_Beer>(entity =>
            {
                entity.HasOne(d => d.Beer)
                    .WithMany(p => p.Mapping_Brewery_Beers)
                    .HasForeignKey(d => d.BeerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mapping_Brewery_Beers_Beer");

                entity.HasOne(d => d.Brewery)
                    .WithMany(p => p.Mapping_Brewery_Beers)
                    .HasForeignKey(d => d.BreweryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mapping_Brewery_Beers_Brewery");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
