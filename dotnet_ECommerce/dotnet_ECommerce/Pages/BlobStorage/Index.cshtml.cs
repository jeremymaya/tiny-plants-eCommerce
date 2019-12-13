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

        public BlobModel(IConfiguration configuration)
        {
            Blob = new Blob(configuration);

        }

        [BindProperty]
        public IFormFile Image { get; set; }

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