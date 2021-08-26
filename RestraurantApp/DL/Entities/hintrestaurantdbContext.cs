using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL.Entities
{
    public partial class hintrestaurantdbContext : DbContext
    {
        public hintrestaurantdbContext()
        {
        }

        public hintrestaurantdbContext(DbContextOptions<hintrestaurantdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("FK__Rating__Restaura__367C1819");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Rating__userId__3587F3E0");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.AvgRating)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("avgRating");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
