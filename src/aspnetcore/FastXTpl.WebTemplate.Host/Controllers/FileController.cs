using FastX;
using FastX.AspNetCore.Controllers;
using FastXTpl.WebTemplate.Host.Models.File;
using Microsoft.AspNetCore.Mvc;

namespace FastXTpl.WebTemplate.Host.Controllers;

/// <summary>
/// File
/// </summary>
public class FileController : XController
{
    private readonly IWebHostEnvironment _env;

    /// <summary>
    /// 
    /// </summary>
    public FileController(IWebHostEnvironment env)
    {
        _env = env;
    }

    /// <summary>
    /// upload
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<UploadResult> Upload(IFormFile file)
    {
        var contentPath = _env.WebRootPath;
        var tempPath = Path.Combine("upload", DateTime.Now.ToString("yyyyMMdd"));
        var path = Path.Combine(contentPath, tempPath);
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var ext = Path.GetExtension(file.FileName);
        if (ext.IsNullOrEmpty())
            throw new UserFriendlyException("文件格式错误");

        var filePath = Ulid.NewUlid() + ext;
        await using var fs = System.IO.File.Create(Path.Combine(path, filePath));
        await file.CopyToAsync(fs);

        return new UploadResult()
        {
            Url = Path.Combine(@"\", tempPath, filePath).Replace(@"\", "/")
        };
    }
}