
using Microsoft.EntityFrameworkCore;
using Modules.Inventory.Domain.Entities;
using Modules.Inventory.Domain.ValueObjects;

namespace Modules.Inventory.Persistence;

internal sealed class InventoryDbContext : DbContext
{
    private const string CONNSTRING = "Server=.;Database=VendTron9000;Trusted_Connection=true;Trust Server Certificate=true";

    internal InventoryDbContext() { }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
        .UseSqlServer(CONNSTRING)
        .UseSeeding((context, b) =>
        {
#pragma warning disable IDE0058
            if (!context.Set<SnackType>().Any())
            {
                context.Set<SnackType>().Add(new SnackType("Chips", Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505")));
                context.Set<SnackType>().Add(new SnackType("Crackers", Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E")));
                context.Set<SnackType>().Add(new SnackType("Drink", Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A")));
                context.Set<SnackType>().Add(new SnackType("Pastry", Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624")));
            }
            if (!context.Set<SnackLocation>().Any())
            {
                context.Set<SnackLocation>().Add(new SnackLocation("A1", Guid.Parse("2F897722-5120-442E-96CA-4FE95ECC86D0")));
                context.Set<SnackLocation>().Add(new SnackLocation("A2", Guid.Parse("2F109C80-878B-494E-8EC0-1E705F3BD84A")));
                context.Set<SnackLocation>().Add(new SnackLocation("A3", Guid.Parse("1E734EB2-9F04-44E2-A8D0-17CDD1E792B2")));
                context.Set<SnackLocation>().Add(new SnackLocation("A4", Guid.Parse("AE1F0E4F-38F5-4755-B65D-FEB86693C5C0")));
                context.Set<SnackLocation>().Add(new SnackLocation("B1", Guid.Parse("F830D720-7893-4BB4-AB65-B8296A892641")));
                context.Set<SnackLocation>().Add(new SnackLocation("B2", Guid.Parse("37061288-0D3E-44A6-936D-EC4D1BE97F3F")));
                context.Set<SnackLocation>().Add(new SnackLocation("B3", Guid.Parse("D58180C5-00B0-41AD-AC87-CCB8F8CD7593")));
                context.Set<SnackLocation>().Add(new SnackLocation("B4", Guid.Parse("C7BED310-6300-44BD-8E61-18B429A87ECA")));
                context.Set<SnackLocation>().Add(new SnackLocation("C1", Guid.Parse("9A8AB531-198A-48F6-8B0D-AB002504D33B")));
                context.Set<SnackLocation>().Add(new SnackLocation("C2", Guid.Parse("D81D3EFD-66E9-4818-9E3A-D51CFFAFEA4F")));
                context.Set<SnackLocation>().Add(new SnackLocation("C3", Guid.Parse("09C87E20-CB01-469B-9E13-900B3089F54C")));
                context.Set<SnackLocation>().Add(new SnackLocation("C4", Guid.Parse("3D75F890-6650-4987-B24F-E89CDDA0C1B8")));
                context.Set<SnackLocation>().Add(new SnackLocation("D1", Guid.Parse("511C0E4F-35CE-44A9-B51D-C662A425DC75")));
                context.Set<SnackLocation>().Add(new SnackLocation("D2", Guid.Parse("F8C94E17-52C0-4A52-A13F-E7E9D73BEE31")));
                context.Set<SnackLocation>().Add(new SnackLocation("D3", Guid.Parse("189CA5F7-B3F5-4FC3-9205-C2AEB800E2C3")));
                context.Set<SnackLocation>().Add(new SnackLocation("D4", Guid.Parse("33E48D66-CE46-4E89-A4EB-2698676F8587")));
            }
            if (!context.Set<Snack>().Any())
            {
                context.Set<Snack>().Add(new Snack("Potato Crisps", 3.05m, 2.70m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), Guid.Parse("2F897722-5120-442E-96CA-4FE95ECC86D0"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Prongles", 1.45m, 1.25m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), Guid.Parse("2F109C80-878B-494E-8EC0-1E705F3BD84A"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Boogles", 2.75m, 2.40m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), Guid.Parse("1E734EB2-9F04-44E2-A8D0-17CDD1E792B2"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Veggie Crisps", 3.65m, 2.95m, Guid.Parse("48119E16-AE82-4B3F-8C91-0B6DA67DF505"), Guid.Parse("AE1F0E4F-38F5-4755-B65D-FEB86693C5C0"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));

                context.Set<Snack>().Add(new Snack("Lieutenants Wafers", 1.80m, 1.50m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), Guid.Parse("F830D720-7893-4BB4-AB65-B8296A892641"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Chweesits", 1.50m, 1.05m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), Guid.Parse("37061288-0D3E-44A6-936D-EC4D1BE97F3F"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Pita Squares", 1.50m, 1.25m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), Guid.Parse("D58180C5-00B0-41AD-AC87-CCB8F8CD7593"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Nyblets", 1.75m, 1.35m, Guid.Parse("DBD74CA6-C24A-4C65-8521-32E083C40A8E"), Guid.Parse("C7BED310-6300-44BD-8E61-18B429A87ECA"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));

                context.Set<Snack>().Add(new Snack("Cola", 1.25m, 1.00m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), Guid.Parse("9A8AB531-198A-48F6-8B0D-AB002504D33B"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Dr. Rumble", 1.50m, 1.25m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), Guid.Parse("D81D3EFD-66E9-4818-9E3A-D51CFFAFEA4F"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Mountain Condensate", 1.50m, 1.15m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), Guid.Parse("09C87E20-CB01-469B-9E13-900B3089F54C"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("EnergyStroke", 1.50m, 1.00m, Guid.Parse("3858958D-A929-497D-A178-6DB5FD14437A"), Guid.Parse("3D75F890-6650-4987-B24F-E89CDDA0C1B8"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));

                context.Set<Snack>().Add(new Snack("Cinnamon Pastry", 0.85m, 0.70m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), Guid.Parse("511C0E4F-35CE-44A9-B51D-C662A425DC75"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Strawberry Pastry", 0.95m, 0.80m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), Guid.Parse("F8C94E17-52C0-4A52-A13F-E7E9D73BEE31"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Blueberry Pastry", 0.75m, 0.65m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), Guid.Parse("189CA5F7-B3F5-4FC3-9205-C2AEB800E2C3"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
                context.Set<Snack>().Add(new Snack("Apple Pastry", 0.75m, 0.60m, Guid.Parse("FAB70135-3BC3-4B50-8E91-E639532F4624"), Guid.Parse("33E48D66-CE46-4E89-A4EB-2698676F8587"), Guid.Parse("C9BFE8BA-7E41-48EE-BB56-DE9CCD29F0C1")));
            }
#pragma warning restore IDE0058
        });

    override protected void OnModelCreating(ModelBuilder modelBuilder)
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
        });

        modelBuilder.Entity<Snack>(entity =>
        {
            entity.ToTable(nameof(Snack));
            entity.ToTable(s => s.HasCheckConstraint("CK_Snack_Price", "Price > 0"));
            entity.ToTable(s => s.HasCheckConstraint("CK_Snack_Cost", "Cost > 0"));
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasConversion(i => i.Value, i => new Identifier<Snack>(i));
            entity.Property(e => e.Label).HasConversion(l => l.Value, l => new Descriptor(l));
            entity.Property(e => e.Label).HasMaxLength(12).IsUnicode(false);
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
                .WithMany(e => e.Snacks)
                .HasForeignKey(e => e.SnackLocationId)
                .OnDelete(DeleteBehavior.Cascade);
        });
#pragma warning restore IDE0058
    }
}
