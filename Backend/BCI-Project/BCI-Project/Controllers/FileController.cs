using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO.Compression;

namespace BCI_Project.Controllers
{
    public class FileController : Controller
    {
        private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
        public FileController()
        {
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }


        [HttpPost(nameof(UploadFiles))]
        [AllowAnonymous]
        public async Task<IActionResult> UploadFiles(string userid,List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No files uploaded");
            }

            var uploadedFiles = new List<string>();

            foreach (var file in files)
            {
                var filePath = Path.Combine(_storagePath,userid, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                uploadedFiles.Add(filePath);
            }

            return Ok(new { UploadedFiles = uploadedFiles });
        }

        [HttpGet(nameof(DownloadFiles))]
        [AllowAnonymous]
        public IActionResult DownloadFiles(string userid)
        {
            var userDirectory = Path.Combine(_storagePath, userid);

            if (!Directory.Exists(userDirectory))
            {
                return NotFound("User directory not found");
            }

            var files = Directory.GetFiles(userDirectory);

            if (files.Length == 0)
            {
                return NotFound("No files found for the user");
            }

            var memoryStream = new MemoryStream();
            using (var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
            {
                foreach (var filePath in files)
                {
                    var fileName = Path.GetFileName(filePath);
                    var entry = zipArchive.CreateEntry(fileName, CompressionLevel.Fastest);

                    using (var entryStream = entry.Open())
                    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.CopyTo(entryStream);
                    }
                }
            }

            memoryStream.Position = 0;

            var contentType = "application/zip";
            var zipFileName = $"{userid}_files.zip";
            return File(memoryStream, contentType, zipFileName);
        }

    
    }
}
