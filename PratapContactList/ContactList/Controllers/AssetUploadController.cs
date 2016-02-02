using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.WindowsAzure.Storage;
using ContactList.Models;
using System.Configuration;

namespace ContactList.Controllers
{
    public class AssetUploadController : ApiController
    {
        

        public async Task<AssetsResponse> PostFormData()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());

            var files = provider.Files;
            var file1 = files[0];
            var fileStream = await file1.ReadAsStreamAsync();

            var extension = ExtractExtension(file1);
            var contentType = file1.Headers.ContentType.ToString();
            var imageName = string.Concat(Guid.NewGuid().ToString(), extension);
            var storageConnectionString = "";// ";
            storageConnectionString = ConfigurationManager.AppSettings["StorageConnectionString"];
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("images");
            container.CreateIfNotExists();

            var blockBlob = container.GetBlockBlobReference(imageName);
            blockBlob.Properties.ContentType = contentType;
            blockBlob.UploadFromStream(fileStream);

            var assetResponse = new AssetsResponse
            {
                AssetUri = blockBlob.Uri.ToString()
            };

            return assetResponse;
        }

        public static string ExtractExtension(HttpContent file)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            var fileStreamName = file.Headers.ContentDisposition.FileName;
            var fileName = new string(fileStreamName.Where(x => !invalidChars.Contains(x)).ToArray());
            var extension = Path.GetExtension(fileName);

            return extension;
        }
    }
}
