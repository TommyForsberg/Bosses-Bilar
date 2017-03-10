using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BossesBilar.Models.Entities
{
    public partial class CarsContext : DbContext
    {
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Car)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Car_ToOwner");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}