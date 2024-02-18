using ShoppingWebsite.Repository;

namespace ShoppingWebsite.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IProductRepository ProductRepository { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Save();
    }
}
