using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MyDbContext myDb;

        public CustomerRepository(MyDbContext myDbContext)
        {
            myDb = myDbContext;
        }

        public void Create(Customer customer)
        {
            myDb.Customers.Add(customer);
            
        }
        
        public void Update(Customer customer, int customerId)
        {
            var checkDb = myDb.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (checkDb != null)
            {
                checkDb.Password = customer.Password;
                checkDb.ContactName = customer.ContactName;
                checkDb.Address = customer.Address;
                checkDb.Phone = customer.Phone;
                
            }
        }

        public void Delete(int customerId)
        {
            var checkCustomerDb = myDb.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (checkCustomerDb != null)
            {
                myDb.Customers.Remove(checkCustomerDb);
                
            }
        }

        public Customer checkLogin(string contactName, string password)
        {
            return myDb.Customers.FirstOrDefault(c => c.ContactName == contactName && c.Password == password);
        }

        public List<Customer> GetList()
        {
            return myDb.Customers.ToList();
        }

        public Customer GetById(int customerId)
        {
            return myDb.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            
        }
    }
}
