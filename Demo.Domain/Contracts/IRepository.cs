namespace Demo.Domain.Contracts
{
    public interface IRepository<TAggregateRoute, TKey>
        where TAggregateRoute:class, 
        IAggregateRoute<TKey> where TKey : IComparable
    {
        void Add(TAggregateRoute entity);
        Task AddAsync(TAggregateRoute entity);
    }
}
