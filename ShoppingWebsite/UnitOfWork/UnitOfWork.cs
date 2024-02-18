using Microsoft.EntityFrameworkCore.Storage;
using ShoppingWebsite.Data;
using ShoppingWebsite.Repository;

namespace ShoppingWebsite.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly MyDbContext _context;
        private IAccountRepository _accountRepository;
        private ICustomerRepository _customerRepository;
        private IProductRepository _productRepository;

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

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_context);
                return _productRepository;
            }
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                // Nếu có lỗi, hủy bỏ giao dịch
                RollbackTransaction();
                throw;
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction.Dispose();
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
