﻿
namespace Modules.Inventory.Domain.Entities;

public abstract class Entity<T>
{
    public abstract Identifier<T> Id { get; init; }
}
