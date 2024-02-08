using ShoppingWebsite.Repository;

namespace ShoppingWebsite.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        void Save();
    }
}
