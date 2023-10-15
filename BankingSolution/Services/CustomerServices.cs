using BankingSolution.DataModels;
using BankingSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSolution.Services
{
    public class CustomerServices
    {
        private readonly DataContext _context;
        public CustomerServices(DataContext dataContext)
        {
            _context = dataContext;
        }

        public  Customer GetCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return new Customer();
            }
            var customer = _context.Customers
        .Include(x => x.Accounts).ThenInclude(a => a.Transactions)
        .SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return new Customer();
            }

            return (Customer)customer;
        }
        public async Task<Customer> GenerateCustomer(Customer customer)
        {
            if (_context.Customers == null)
            {
                return new Customer(); 
            }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;

        }
        public Customer handlingDataToInser(_Customer customer)
        {
            Customer _customer = new Customer
            {
                Name = customer.Name,
                LastName = customer.LastName
            };
            return _customer;
        }
        public double TotalBalance(double customerId)
        {
            Customer customer  = _context.Customers
        .Include(x => x.Accounts).ThenInclude(a => a.Transactions)
        .SingleOrDefault(c => c.Id == customerId) ?? new Customer();
            double balance = 0;
            foreach(var account in customer.Accounts)
            {
                 balance += account.Balance;
            }
            return balance;
        }

    }
}
