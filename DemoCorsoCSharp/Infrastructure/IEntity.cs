namespace DemoCorsoCSharp.Infrastructure;

public interface IEntity<TKey>
{
    TKey Id { get; set; }
}
