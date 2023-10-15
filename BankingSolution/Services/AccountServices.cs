using BankingSolution.DataModels;
using BankingSolution.Models;

namespace BankingSolution.Services
{
    public class AccountServices
    {
        private readonly DataContext _context;
        public AccountServices(DataContext dataContext)
        {
            _context = dataContext;

        }
        public async Task<Account> GenerateAccount(Account account, double initialCredit)
        {
            if (account == null)
            {
                return new Account(); 
            }
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();


            return account;
        }


        public Account handlingDataToInser(double initialCredit,int userId)
        {
            Account _account = new Account
            {
                Balance = initialCredit,
                CustomerId = userId

            };
            return _account;
        }





    }
}
