using BAL.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ApplicationConfig;
using Model.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsers();
                return Ok(new ResponseModel { Message = "Success.", Status = ApiStatus.Success, Data = users });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = "Error.", Status = ApiStatus.SystemError });
            }
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            try
            {
                var user = await _userService.GetUserById(id);
                return Ok(new ResponseModel { Message = "Success.", Status = ApiStatus.Success, Data = user });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = "Error.", Status = ApiStatus.SystemError });
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(UserDTO inputModel)
        {
            try
            {
                await _userService.CreateUser(inputModel);
                return Ok(new ResponseModel { Message = "Success.", Status = ApiStatus.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = "Error.", Status = ApiStatus.SystemError });
            }
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO inputModel)
        {
            try
            {
                await _userService.UpdateUser(inputModel);
                return Ok(new ResponseModel { Message = "Success.", Status = ApiStatus.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = "Error.", Status = ApiStatus.SystemError });
            }
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok(new ResponseModel { Message = "Success.", Status = ApiStatus.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = "Error.", Status = ApiStatus.SystemError });
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginUserDTO inputModel)
        {
            try
            {
                await _userService.LoginUser(inputModel);
                return Ok(new ResponseModel { Message = "Login Success.", Status = ApiStatus.Success });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, Status = ApiStatus.SystemError });
            }
        }
    }
}
