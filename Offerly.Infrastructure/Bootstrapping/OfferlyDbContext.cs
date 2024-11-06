using Microsoft.EntityFrameworkCore;
using Offerly.Domain.Entities;

namespace Offerly.Infrastructure.Bootstrapping;

public partial class OfferlyDbContext : DbContext
{
    public OfferlyDbContext()
    {
    }

    public OfferlyDbContext(DbContextOptions<OfferlyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OfferEntity> Offers { get; set; }

    public virtual DbSet<OfferDetailEntity> OfferDetails { get; set; }

    public virtual DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OfferEntity>(entity =>
        {
            entity.ToTable("Offers");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

        });

        modelBuilder.Entity<OfferDetailEntity>(entity =>
        {
            entity.ToTable("OfferDetails");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Offer).WithMany(p => p.OfferDetails)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfferDetails_Offers");

            entity.HasOne(d => d.Product).WithMany(p => p.OfferDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OfferDetails_Products");
        });

        modelBuilder.Entity<ProductEntity>(entity =>
        {
            entity.ToTable("Products");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}