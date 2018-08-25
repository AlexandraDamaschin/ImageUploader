using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageUploader.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploader.Controllers
{
    [Route("api/image")]
    public class ImagesController : Controller
    {
        private readonly IImageHandler _imageHandler;

        public ImagesController(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }

        // Uplaods an image to the server.
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            return await _imageHandler.UploadImage(file);
        }
    }
}