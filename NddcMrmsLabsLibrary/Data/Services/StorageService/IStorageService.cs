using Microsoft.AspNetCore.Http;
using NddcMrmsLabsLibrary.Model.StorageModel;

namespace NddcMrmsLabsLibrary.Data.Services.StorageService
{
    public interface IStorageService
    {
        Task<MyBlobResponseModel> DeleteAsync(string fileName);
        Task<MyBlobModel> DownloadAsync(string blobFilename);
        Task<List<MyBlobModel>> ListAsync();
        Task<MyBlobResponseModel> UploadAsync(IFormFile file, string fileName);
        Task<MyBlobResponseModel> UploadStreamAsync(MemoryStream stream, string fileName, string contentType);
    }
}