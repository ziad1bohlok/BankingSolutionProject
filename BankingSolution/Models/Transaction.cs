using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingSolution.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Define a foreign key to relate Transaction to Account
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public double Value { get; set; }
    }
}
