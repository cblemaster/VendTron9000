namespace Modules.Inventory.Domain.Entities;

internal class SnacksForSale : Entity<SnacksForSale>
{
    internal IEnumerable<Snack> Snacks { get; init; } = [];
    internal override Identifier<SnacksForSale> Id { get; init; }

    private SnacksForSale() { }

    internal SnacksForSale(IEnumerable<Snack> snacks, Guid id)
    {
        Snacks = snacks;
        Id = new Identifier<SnacksForSale>(id);
    }

    internal SnacksForSale(IEnumerable<Snack> snacks) : this(snacks, Guid.NewGuid()) { }

    internal void AddSnacks(IEnumerable<Snack> snacks) => Snacks.ToList().AddRange(snacks);

    internal void RemoveSnack(Snack snack)
    {
        if (Snacks.Contains(snack))
        {
            _ = Snacks.ToList().Remove(snack);
        }
    }
}
