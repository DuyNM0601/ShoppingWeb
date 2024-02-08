using ShoppingWebsite.Models;

namespace ShoppingWebsite.Repository
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        void Update(Customer customer, int customerId);
        void Delete(int customer);
        List<Customer> GetList();
        Customer GetById(int id);
    }
}
