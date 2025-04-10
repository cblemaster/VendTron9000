
using Microsoft.EntityFrameworkCore;
using Modules.Inventory.Domain.Entities;
using Modules.Inventory.Domain.ValueObjects;

namespace Modules.Inventory.Persistence;

internal sealed class InventoryDbContext : DbContext
{
    internal InventoryDbContext() { }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
#pragma warning disable IDE0058
        modelBuilder.HasDefaultSchema("Inventory");

        modelBuilder.Entity<SnackType>(entity =>
        {
            entity.ToTable(nameof(SnackType));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasConversion(i => i.Value, i => new Identifier<SnackType>(i));
            entity.Property(e => e.Name).HasMaxLength(12).IsUnicode(false);
            entity.HasIndex(e => e.Name).IsUnique();
        });

        modelBuilder.Entity<SnackLocation>(entity =>
        {
            entity.ToTable(nameof(SnackLocation));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasConversion(i => i.Value, i => new Identifier<SnackLocation>(i));
            entity.Property(e => e.Code).HasConversion(c => c.Value, c => new Descriptor(c));
            entity.Property(e => e.Code).HasMaxLength(2).IsUnicode(false);
            entity.HasIndex(e => e.Code).IsUnique();
            entity.Property(e => e.SnackId).HasConversion(i => i.Value, i => new Identifier<Snack>(i));
        });

        modelBuilder.Entity<Snack>(entity =>
        {
            entity.ToTable(nameof(Snack));
            entity.ToTable(s => s.HasCheckConstraint("CK_Snack_Price", "Price > 0"));
            entity.ToTable(s => s.HasCheckConstraint("CK_Snack_Cost", "Cost > 0"));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasConversion(i => i.Value, i => new Identifier<Snack>(i));
            entity.Property(e => e.Label).HasConversion(l => l.Value, l => new Descriptor(l));
            entity.Property(e => e.Label).HasMaxLength(30).IsUnicode(false);
            entity.HasIndex(e => e.Label).IsUnique();
            entity.Property(e => e.Price).HasConversion(p => p.Amount, p => new Currency(p, "USD"));
            entity.Property(e => e.Cost).HasConversion(c => c.Amount, c => new Currency(c, "USD"));
            entity.Property(e => e.SnackTypeId).HasConversion(i => i.Value, i => new Identifier<SnackType>(i));
            entity.Property(e => e.SnackLocationId).HasConversion(i => i.Value, i => new Identifier<SnackLocation>(i));
            entity.HasOne(e => e.SnackType)
                .WithMany(e => e.Snacks)
                .HasForeignKey(e => e.SnackTypeId)
                .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.SnackLocation)
                .WithOne(e => e.Snack)
                .HasForeignKey<Snack>(e => e.SnackLocationId)
                .OnDelete(DeleteBehavior.Cascade);
        });
#pragma warning restore IDE0058
    }
}
