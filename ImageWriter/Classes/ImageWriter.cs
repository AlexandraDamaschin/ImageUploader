using System;
using System.IO;
using System.Threading.Tasks;
using ImageWriter.Helper;
using ImageWriter.Interface;
using Microsoft.AspNetCore.Http;

namespace ImageWriter.Classes
{
    public class ImageWriter : IImageWriter
    {
        //methood declared in the IImageWriter interface
        public async Task<string> UploadImage(IFormFile file)
        {
            //if it`s an image file we write it with a new name
            //for security reasons 
            if (CheckIfImageFile(file))
            {
                // return the name back to the user
                return await WriteFile(file);
            }
            // If file is invalid, we return an error message
            return "Invalid image file";
        }

        // Method to check if file is image file
        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }

        // Method to write file onto the disk
        public async Task<string> WriteFile(IFormFile file)
        {
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                //new name it`s just a new random GUID transformed to string
                fileName = Guid.NewGuid().ToString() + extension; //Create a new Name for the file due to security reasons.
                //add new image to path: wwwroot
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                //copy image to path
                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return fileName;
        }
    }
}
