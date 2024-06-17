using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionSystemAPI.DTO;
using TransactionSystemAPI.Interface;
using TransactionSystemAPI.Model;

namespace TransactionSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransaction transaction;

        public TransactionController(ITransaction transaction)
        {
            this.transaction = transaction;
        }
        [HttpGet]
        public async Task<IActionResult> GetTransaction()
        {
            var result= await this.transaction.GetTransactions();
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionDTO transaction)
        {
            var res = new TransactionModel
            {
                Date = transaction.Date,
                Credit = transaction.Credit,
                Debit = transaction.Debit,
                RunningBalance = transaction.RunningBalance,
                Description = transaction.Description,
            };
            var result = await this.transaction.CreateAsync(res);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
