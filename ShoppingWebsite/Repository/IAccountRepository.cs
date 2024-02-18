using ShoppingWebsite.Models;

namespace ShoppingWebsite.Repository
{
    public interface IAccountRepository
    {
        void Create(Accounts accounts);
        void Update(Accounts accounts, int accountId);
        void Delete(int accountId);
        List<Accounts> GetList();
        Accounts GetById(int accountId);
        Accounts GetAccount(string username, string password);
    }
}
