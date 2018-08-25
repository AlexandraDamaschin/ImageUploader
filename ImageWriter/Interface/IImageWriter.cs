using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ImageWriter.Interface
{
    public interface IImageWriter
    {
        // populate the IImageWriter.cs interface so we can inject it in our handlers
        Task<string> UploadImage(IFormFile file);
    }
}
