using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyDbContext _context;

        public AccountRepository(MyDbContext context)
        {
            _context = context;
        }

        public void Create(Accounts accounts)
        {
            
            _context.Accounts.Add(accounts);
           
        }

        public void Update(Accounts accounts, int accountId)
        {
           

            var check = _context.Accounts.FirstOrDefault(a => a.AccountID == accountId);
            if (check != null)
            {
                
                    check.FullName = accounts.FullName;
                    check.UserName = accounts.UserName;
                    check.Password = accounts.Password;
                    check.Type = accounts.Type;
                    
                
            }
           
        }


        public void Delete(int accountId)
        {
            var account = GetById(accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                
            }
        }

        public List<Accounts> GetList()
        {
            return _context.Accounts.ToList();
        }

        public Accounts GetById(int accountId)
        {
            return _context.Accounts.FirstOrDefault(c => c.AccountID == accountId);
        }
    }
}
