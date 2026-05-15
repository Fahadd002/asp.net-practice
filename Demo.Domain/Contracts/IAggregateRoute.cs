namespace Demo.Domain.Contracts
{
    public interface IAggregateRoute<TKey>
    {
        TKey Id { get; set; }
    }
}
