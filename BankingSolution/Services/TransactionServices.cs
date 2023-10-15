using BankingSolution.DataModels;
using BankingSolution.Models;

namespace BankingSolution.Services
{
    public class TransactionServices
    {
        private readonly DataContext _context;
        public TransactionServices(DataContext dataContext)
        {
            _context = dataContext;

        }
        public async Task<Transaction> GenerateTransaction(Transaction transaction)
        {
            if (_context.Transactions == null)
            {
                return new Transaction();
            }
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }


        public Transaction handlingDataToInser(_Transaction transaction,int accountId)
        {
            Transaction _Transaction = new Transaction
            {
               AccountId=accountId,
               Value=transaction.Value
            };
            return _Transaction;
        }


    }
}


