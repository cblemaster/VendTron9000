
using Microsoft.EntityFrameworkCore;
using Modules.Inventory.Domain.Entities;
using Modules.Inventory.Domain.Enumerations;

namespace Modules.Inventory.Persistence;

internal sealed class InventoryDbContext : DbContext
{
    private const string CONNSTRING = "Server=.;Database=VendTron9000;Trusted_Connection=true;Trust Server Certificate=true";

    internal InventoryDbContext() { }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(CONNSTRING);

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
#pragma warning disable IDE0058
        modelBuilder.HasDefaultSchema("Inventory");

        modelBuilder.Entity<Domain.Entities.Inventory>(entity =>
        {
            entity.ToTable(nameof(Domain.Entities.Inventory));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasConversion(i => i.Value, i => new Identifier<Domain.Entities.Inventory>(i));
            entity.Property(e => e.InventoryType).HasConversion(i => (int)i, i => (InventoryType)i);
        });

        modelBuilder.Entity<Domain.Entities.Snack>(entity =>
        {
            entity.ToTable(nameof(Domain.Entities.Snack));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasConversion(i => i.Value, i => new Identifier<Domain.Entities.Snack>(i));
            entity.Property(e => e.Label).HasConversion(l => l.Value, l => new Domain.ValueObjects.Descriptor(l));
            entity.Property(e => e.Label).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Price).HasConversion(p => p.Amount, p => new Domain.ValueObjects.Currency(p, "USD"));
            entity.Property(e => e.Cost).HasConversion(c => c.Amount, c => new Domain.ValueObjects.Currency(c, "USD"));
            entity.Property(e => e.MachineInventoryIndex).HasConversion(i => i.Value, i => new Domain.ValueObjects.Descriptor(i));
            entity.Property(e => e.MachineInventoryIndex).HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.InventoryId).HasConversion(i => i.Value, i => new Identifier<Domain.Entities.Inventory>(i));
            entity.Property(e => e.SnackType).HasConversion(i => (int)i, i => (SnackType)i);
        });

        modelBuilder.Entity<Domain.Entities.Inventory>()
            .HasMany(e => e.Snacks)
            .WithOne(e => e.Inventory)
            .HasForeignKey(e => e.InventoryId)
            .OnDelete(DeleteBehavior.Cascade);
#pragma warning restore IDE0058
    }
}
