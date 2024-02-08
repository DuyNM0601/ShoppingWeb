using ShoppingWebsite.Data;
using ShoppingWebsite.Repository;

namespace ShoppingWebsite.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _context;
        private IAccountRepository _accountRepository;
        private ICustomerRepository _customerRepository;
        // Khai báo các Repository khác nếu cần

        public UnitOfWork(MyDbContext context)
        {
            _context = context;
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository == null)
                    _accountRepository = new AccountRepository(_context);
                return _accountRepository;
            }
        }
        // Triển khai các Repository khác nếu cần

        public ICustomerRepository CustomerRepository
        {
            get
            {
                if (_customerRepository == null)
                    _customerRepository = new CustomerRepository(_context);
                return _customerRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
