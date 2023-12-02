using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NddcMrmsLabsLibrary.Model.StorageModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLabsLibrary.Data.Services.StorageService
{
    public class AWSStorageService : IStorageService
    {
        private readonly string _bucketName;
        private readonly string _accessKey;
        private readonly string _secretAccessKey;
        public AWSStorageService(IConfiguration configuration)
        {
            _bucketName = configuration.GetConnectionString("AWSBucketName");
            _accessKey = configuration.GetConnectionString("AWSAccessKeyId");
            _secretAccessKey = configuration.GetConnectionString("AWSSecreteAccessKey");
        }

        public Task<MyBlobModel> DownloadAsync(string blobFilename)
        {
            throw new NotImplementedException();
        }

        public Task<List<MyBlobModel>> ListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<MyBlobResponseModel> UploadAsync(IFormFile file, string fileName)
        {
            MyBlobResponseModel response = new();
            string myFileName = fileName;
            using (var amazonS3client = new AmazonS3Client(_accessKey, _secretAccessKey, Amazon.RegionEndpoint.EUNorth1))
            {

                using (var memorystream = new MemoryStream())
                {
                    file.CopyTo(memorystream);
                    var request = new TransferUtilityUploadRequest()
                    {
                        InputStream = memorystream,
                        Key = myFileName,
                        BucketName = _bucketName,
                        ContentType = file.ContentType
                    };

                    var transferutility = new TransferUtility(amazonS3client);
                    await transferutility.UploadAsync(request);

                    response.Blob.Uri = request.Key;
                }
            }

            return response;
        }

        public async Task<MyBlobResponseModel> UploadStreamAsync(MemoryStream stream, string fileName, string contentType)
        {
            MyBlobResponseModel response = new();
            string myFileName = fileName;
            using (var amazonS3client = new AmazonS3Client(_accessKey, _secretAccessKey, Amazon.RegionEndpoint.EUNorth1))
            {

                var request = new TransferUtilityUploadRequest()
                {
                    InputStream = stream,
                    Key = myFileName,
                    BucketName = _bucketName,
                    ContentType = contentType
                };

                var transferutility = new TransferUtility(amazonS3client);
                await transferutility.UploadAsync(request);

                response.Blob.Uri = request.Key;
            }

            return response;
        }

        public async Task<MyBlobResponseModel> DeleteAsync(string fileName)
        {
            MyBlobResponseModel response = new();
            string myFileName = fileName;

            using (var amazonS3client = new AmazonS3Client(_accessKey, _secretAccessKey, Amazon.RegionEndpoint.EUNorth1))
            {
                var transferutility = new TransferUtility(amazonS3client);
                await transferutility.S3Client.DeleteObjectAsync(new Amazon.S3.Model.DeleteObjectRequest()
                {
                    BucketName = _bucketName,
                    Key = myFileName

                });

                response.Status = "Success";
            }

            return response;
        }
    }
}
