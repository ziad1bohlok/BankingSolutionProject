using BankingSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingSolution.DataModels
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
      
    }
   
}
