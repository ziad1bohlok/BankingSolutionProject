using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSolution.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Balance { get; set; }


        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
       
        public List<Transaction> Transactions { get; set; } = new();

    }
}
