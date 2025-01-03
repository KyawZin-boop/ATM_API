using BAL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Model.ApplicationConfig;
using Model.DTO;

namespace API.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> Deposit(TransactionDTO inputModel)
        {
            try
            {
                await _transactionService.Deposit(inputModel);
                return Ok(new ResponseModel { Message = "Deposit Success.", Status = ApiStatus.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, Status = ApiStatus.SystemError });
            }
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDTO inputModel)
        {
            try
            {
                await _transactionService.Withdraw(inputModel);
                return Ok(new ResponseModel { Message = "Withdraw Success.", Status = ApiStatus.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, Status = ApiStatus.Success });
            }
        }

        [HttpGet("GetTransactions")]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                var transactions = await _transactionService.GetTransactions();
                return Ok(new ResponseModel { Message = "Success.", Data = transactions, Status = ApiStatus.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, Status = ApiStatus.SystemError });
            }
        }

        [HttpGet("GetTransactionByUserID")]
        public async Task<IActionResult> GetTransactionByUserID(Guid id)
        {
            try
            {
                var transactions = await _transactionService.GetTransactionByUserID(id);
                return Ok(new ResponseModel { Message = "Success.", Data = transactions, Status = ApiStatus.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, Status = ApiStatus.SystemError });
            }
        }
    }
}
