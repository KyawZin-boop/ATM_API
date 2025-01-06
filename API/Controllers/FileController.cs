using Asp.Versioning;
using BAL.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.ApplicationConfig;

namespace API.Controllers
{
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileUploadService _fileService;

        public FileController(IFileUploadService fileUploadService)
        {
            _fileService = fileUploadService;
        }

        [HttpGet("GetAllFiles")]
        public async Task<IActionResult> GetAllFiles()
        {
            try
            {
                var files = await _fileService.GetAllFiles();
                return Ok(new ResponseModel { Message = "Success.", Status = ApiStatus.Success, Data = files });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, Status = ApiStatus.SystemError });
            }
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                var uri = await _fileService.UploadFile(file);
                return Ok(new ResponseModel { Message = "File uploaded successfully.", Status = ApiStatus.Success, Data = uri });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Message = ex.Message, Status = ApiStatus.SystemError });
            }
        }
    }
}
