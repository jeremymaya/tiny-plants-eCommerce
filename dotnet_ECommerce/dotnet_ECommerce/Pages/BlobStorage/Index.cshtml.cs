using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;

namespace dotnet_ECommerce.Pages.BlobStorage
{
    public class BlobModel : PageModel
    {
        public Blob Blob { get; set; }

        /// <summary>
        /// Constructor that takes in IConfiguration interface to access the Blob connection strings stored in configuration
        /// </summary>
        /// <param name="configuration"></param>
        public BlobModel(IConfiguration configuration)
        {
            Blob = new Blob(configuration);

        }

        /// <summary>
        /// Bind the image path to property Image so that it is grabbing the HTTP request
        /// </summary>
        [BindProperty]
        public IFormFile Image { get; set; }

        /// <summary>
        /// Get the full path of the image that is to be uploaded to Blob
        /// Findthe container on Blob storage by specifying the container name
        /// Create a file in the specified file path then copy the file
        /// Finally upload the image to Blob storage by adding the image to the container
        /// </summary>
        /// <returns>Returns the same page</returns>
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var filePath = Path.GetTempFileName();
            CloudBlobContainer blobContainer = await Blob.GetContainer("products");

            using (var stream = System.IO.File.Create(filePath))
            {
                await Image.CopyToAsync(stream);
            }

            await Blob.UploadFile(blobContainer, Image.FileName, filePath);
            return Page();
        }
    }
}