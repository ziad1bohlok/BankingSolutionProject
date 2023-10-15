namespace BankingSolution.Models
{
    public class _Account
    {
        public double Balance { get; set; }
        public _Account(double balance, int customerId)
        {
            Balance = balance;
           
        }
    }
}
