using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models
{
    public class Blob
    {
        public CloudStorageAccount CloudStorageAccount { get; set; }
        public CloudBlobClient CloudBlobClient { get; set; }


        public Blob(IConfiguration configuration)
        {
            var storageCreds = new StorageCredentials(configuration["StorageAccountName"], configuration["BlobKey"]);
            CloudStorageAccount = new CloudStorageAccount(storageCreds, true);
            CloudBlobClient = CloudStorageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// Get or create a full container from Azure Blob Storage
        /// </summary>
        /// <param name="containerName">name of the desired container stored in Azure</param>
        /// <returns>Cloud Container from Azure directly</returns>
        public async Task<CloudBlobContainer> GetContainer(string containerName)
        {
            CloudBlobContainer cbc = CloudBlobClient.GetContainerReference(containerName);
            await cbc.CreateIfNotExistsAsync();

            await cbc.SetPermissionsAsync(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            return cbc;
        }

        /// <summary>
        /// Add a file to specific container within Azure Storage
        /// </summary>
        /// <param name="container">name of container to add file to</param>
        /// <param name="filename">name of file to be added</param>
        /// <param name="filepath">local directory location of file to be uploaded</param>
        public async Task UploadFile(CloudBlobContainer container, string filename, string filepath)
        {
            // Upload the file:
            var blobFile = container.GetBlockBlobReference(filename);

            await blobFile.UploadFromFileAsync(filepath);
        }

        /// <summary>
        /// Retrieve a specific file from Azure Storage and download to local machine
        /// </summary>
        /// <param name="container">name of container you are retrieving from in Azure Storage</param>
        /// <param name="filename">name of file to be downloaded</param>
        /// <param name="saveLocation">location to save the downloaded file</param>
        public async Task DownloadFile(CloudBlobContainer container, string filename, string saveLocation)
        {
            //Download a file:
            var newBlob2 = container.GetBlockBlobReference(filename);
            await newBlob2.DownloadToFileAsync(saveLocation, FileMode.Create);
            // find a way to get a reference to the blob in azure
        }

        /// <summary>
        /// Get a specific blob located in Azure Storage
        /// </summary>
        /// <param name="imageName">name of image file</param>
        /// <param name="containerName">name of container blob is stored in</param>
        /// <returns>full cloud blob</returns>
        public CloudBlob GetBlob(string imageName, string containerName)
        {
            var container = CloudBlobClient.GetContainerReference(containerName);
            CloudBlob blob = container.GetBlobReference(imageName);
            return blob;
        }

        /// <summary>
        /// Remove a blob from Azure storage
        /// </summary>
        /// <param name="container">name of container blob is stored in</param>
        /// <param name="filename">name of blob file</param>
        public async Task DeleteBlob(CloudBlobContainer container, string filename)
        {
            // Get a reference to a blob named "myblob.txt".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);

            // Delete the blob.
            await blockBlob.DeleteAsync();
        }
    }
}