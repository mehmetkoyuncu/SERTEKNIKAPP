

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace SERTEKNIKAPP.SERVICE
{  
    public class ImageService
    {
        private readonly Cloudinary _cloudinary;

        public ImageService()
        {

            Account? account = new Account();
            account.ApiKey = "387744197362117";
            account.ApiSecret = "FZsNPlqNh7hzIZiYdFez96YhhmQ";
            account.Cloud = "dkzqdpw84";
            _cloudinary = new Cloudinary(account);
        }
        public async Task<string> UploadAsync(IFormFile formFile)
        {
            if (formFile == null || formFile.Length == 0)
                throw new ArgumentException("Yanlis dosya formati.");

            var imageUploadParams = new ImageUploadParams
            {
                File = new FileDescription(formFile.FileName, formFile.OpenReadStream()),
                UseFilename = false,
                UniqueFilename = true,
                Overwrite = false
            };

            var imageUploadResult = await _cloudinary.UploadAsync(imageUploadParams);

            if (imageUploadResult.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("Image upload failed.");

            return imageUploadResult.Url.ToString();
        }
    }
}
