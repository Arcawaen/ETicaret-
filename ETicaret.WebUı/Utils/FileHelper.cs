using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Eticaret.WebUI.Utils
{
    public class FileHelper
    {
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string filePath = "/Img/")
        {
            var fileName = "";
            if (formFile != null && formFile.Length > 0)
            {
                fileName = formFile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using var stream = new FileStream(directory + fileName, FileMode.Create);
                await formFile.CopyToAsync(stream);
            }
            return fileName;
        }

        public static bool FileRemover(string fileName, string filePath = "/Img/")
        {
            if (string.IsNullOrEmpty(fileName)) return false;
            
            try
            {
                string directory = Directory.GetCurrentDirectory() + "/wwwroot" + filePath;
                var fullPath = directory + fileName;
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
    }
}
