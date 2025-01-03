using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using BAL.IServices;
using Microsoft.AspNetCore.Http;
using Model.Enitities;
using Repository.UnitOfWork;

namespace BAL.Services
{
    internal class FileUploadService : IFileUploadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly BlobContainerClient _fileContainer;
        private readonly string storageKey = "txfHd/JFnavTxjBoukBnzvHshXOKO+xmqyyWxqZV+z4fA4+YprpoICqJOpxazfqVrdwxo7OLblIZAN92b8dwmA==";
        private readonly string storageAccName = "fusionseed";
        private readonly string containerName = "trainingdev";

        public FileUploadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            var credential = new StorageSharedKeyCredential(storageAccName, storageKey);
            var blobUri = $"https://{storageAccName}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
            _fileContainer = blobServiceClient.GetBlobContainerClient(containerName);
        }

        public async Task<IEnumerable<Files>> GetAllFiles()
        {
            try
            {
                var files = await _unitOfWork.Files.GetByCondition(x => x.ActiveFlag);
                return files;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Uri> UploadFile(IFormFile file)
        {
            try
            {
                var fileName = Path.GetFileNameWithoutExtension(file.FileName) + "_" + System.Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var blobClient = _fileContainer.GetBlobClient(fileName);
                using (var stream = file.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream);
                }

                var uploadFile = new Files()
                {
                    FileName = fileName,
                    Uri = blobClient.Uri.ToString(),
                    ContentType = file.ContentType,
                };
                await _unitOfWork.Files.Add(uploadFile);
                await _unitOfWork.SaveChangesAsync();

                return blobClient.Uri;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
