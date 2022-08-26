using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Application.DataContext
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; } = null!;
        public virtual DbSet<Items> Items { get; set; } = null!;
        public virtual DbSet<Options> Options { get; set; } = null!;
        public virtual DbSet<Subcategory> Subcategory { get; set; } = null!;
        public virtual DbSet<User> User { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.SubCatId).HasColumnName("SubCatID");

                entity.HasOne(d => d.SubCat)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.SubCatId)
                    .HasConstraintName("FK_Items");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.InverseCatagory)
                    .HasForeignKey(d => d.CatagoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Catagory");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
