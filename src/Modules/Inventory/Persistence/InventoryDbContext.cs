
using Microsoft.EntityFrameworkCore;

namespace Modules.Inventory.Persistence;

internal sealed class InventoryDbContext : DbContext
{
    private const string CONNSTRING = "Server=.;Database=VendTron9000;Trusted_Connection=true;Trust Server Certificate=true";

    internal InventoryDbContext() { }

    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(CONNSTRING);
    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        // specify schema

        // inventory entity
        // to table
        // key
        // props
        
        // snack entity
        // to table
        // key
        // props
        // fk : snack has one inventory with many snacks; join snack.inventoryId to inventory.id
    }
}
