using BankingSolution.DataModels;
using BankingSolution.Models;
using BankingSolution.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AccountServices _accountServices;
        private readonly CustomerServices _customerServices;
        private readonly TransactionServices _transactionServices;
        public CustomerController(AccountServices accountServices, CustomerServices customerServices, TransactionServices transactionServices)
        {
            _accountServices = accountServices;
            _customerServices = customerServices;
            _transactionServices = transactionServices;
        }
        [HttpGet("GetCustomerById")]
        public Customer GetCustomer([FromHeader(Name ="CustomerId")] int Id)
        {
          return  _customerServices.GetCustomer(Id);

        }
        [HttpPost("CreateCustomer")]

        public async Task<String> GenerateCustomer([FromBody] _Customer customer)
        {

            Customer customerToGenerate = await _customerServices.GenerateCustomer(_customerServices.handlingDataToInser(customer)); 
            return ($"Customer Name :{customerToGenerate.Name}"+" "+$"{customerToGenerate.LastName}");
            
        }
        [HttpPost("AutoCreateAccountByCustomerId")]
       public async Task<ActionResult> AutoCreateAccount([FromHeader] int UserId,double initialCredit)
        {
            Customer _customer= _customerServices.GetCustomer(UserId);
            if(_customer==null || string.IsNullOrEmpty(_customer.Name)) return BadRequest("No elements found.");
            Account accountToCreat = await _accountServices.GenerateAccount(_accountServices.handlingDataToInser(initialCredit, UserId), initialCredit);
            if (initialCredit != 0)
            {
                _Transaction transaction1 = new(initialCredit);
                Transaction transaction = await _transactionServices.GenerateTransaction(_transactionServices.handlingDataToInser(transaction1, accountToCreat.Id));
            }
            return new JsonResult("Operation succeded!!");
        }
        [HttpGet("GetTotalBalanceForCustomerById")]
        public double GetTotalBalance([FromHeader(Name ="CustomerId")] double customerId)
        {
            return _customerServices.TotalBalance(customerId);

        }
    }
}
