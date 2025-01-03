using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Model.Enitities;
using Repository.Repositories;

namespace BAL.IServices
{
    public interface IFileUploadService
    {
        Task<IEnumerable<Files>> GetAllFiles();
        Task<Uri> UploadFile(IFormFile file);
    }
}
