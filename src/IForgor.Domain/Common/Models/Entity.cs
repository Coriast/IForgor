namespace IForgor.Domain.Common.Models;
public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; protected set; }

    protected Entity(TId id)
    {
        Id = id;
    }

#pragma warning disable CS8618
    protected Entity()
    {
    }
#pragma warning restore CS8618

    public override bool Equals(object? obj)
    {
        // Returns true when the object is of type Entity and the Id is the same
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?)other);
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right) 
    { 
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right) 
    { 
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        // We want two entities to return the same hash code if their Ids are the same
        return Id.GetHashCode();
    }
}
