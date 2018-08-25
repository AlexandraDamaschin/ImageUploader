﻿using System.Threading.Tasks;
using ImageWriter.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageUploader.Handler
{
    //is used by the ImageController to call the image writing component of the program
    //by injecting the handler into the controller
    public interface IImageHandler
    {
        Task<IActionResult> UploadImage(IFormFile file);
    }

    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;
        public ImageHandler(IImageWriter imageWriter)
        {
            _imageWriter = imageWriter;
        }

        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var result = await _imageWriter.UploadImage(file);
            return new ObjectResult(result);
        }
    }
}




