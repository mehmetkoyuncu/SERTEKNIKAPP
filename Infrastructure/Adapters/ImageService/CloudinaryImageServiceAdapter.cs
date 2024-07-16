using Application.Services.ImageService;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Adapters.ImageService;

public class CloudinaryImageServiceAdapter : ImageServiceBase
{
    private readonly Cloudinary _cloudinary;
    private readonly string _videoPath;

    public CloudinaryImageServiceAdapter(IConfiguration configuration)
    {
        Account? account = configuration.GetSection("CloudinaryAccount2").Get<Account>();
        _cloudinary = new Cloudinary(account);
        _videoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/videos");
        if (!Directory.Exists(_videoPath))
        {
            Directory.CreateDirectory(_videoPath);
        }
    }

    public override async Task<string> UploadAsync(IFormFile formFile)
    {
        await FileMustBeInImageFormat(formFile);

        ImageUploadParams imageUploadParams =
            new()
            {
                File = new FileDescription(formFile.FileName, stream: formFile.OpenReadStream()),
                UseFilename = false,
                UniqueFilename = true,
                Overwrite = false
            };
        ImageUploadResult imageUploadResult = await _cloudinary.UploadAsync(imageUploadParams);

        return imageUploadResult.Url.ToString();
    }

    public override async Task<string> UploadVideoAsync(IFormFile formFile)
    {
        if (formFile == null || formFile.Length == 0)
            return "Invalid file.";

        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
        var filePath = Path.Combine(_videoPath, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await formFile.CopyToAsync(stream);
        }

        var fileUrl = $"/videos/{uniqueFileName}";
        return fileUrl;
    }
    public override async Task DeleteAsync(string imageUrl)
    {
        DeletionParams deletionParams = new(GetPublicId(imageUrl));
        await _cloudinary.DestroyAsync(deletionParams);
    }

    private string GetPublicId(string imageUrl)
    {
        int startIndex = imageUrl.LastIndexOf('/') + 1;
        int endIndex = imageUrl.LastIndexOf('.');
        int length = endIndex - startIndex;
        return imageUrl.Substring(startIndex, length);
    }
}
