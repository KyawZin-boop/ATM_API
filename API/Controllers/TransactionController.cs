using BAL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ApplicationConfig;
using Model.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("Deposit")]
        public async Task<IActionResult> Deposit(Guid id,[FromBody] TransactionDTO inputModel)
        {
            try
            {
                await _transactionService.Deposit(id, inputModel);
                return Ok(new ResponseModel { Message = "Deposit Success.", Status = ApiStatus.Success });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw(Guid id, [FromBody] TransactionDTO inputModel)
        {
            try
            {
                await _transactionService.Withdraw(id, inputModel);
                return Ok(new ResponseModel { Message = "Withdraw Success.", Status = ApiStatus.Success });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
