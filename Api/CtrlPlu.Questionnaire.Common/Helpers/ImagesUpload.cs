using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public class ImagesUpload:IImageUpload
    {
        public ImagesUpload(IConfiguration configuration, IHostingEnvironment hostingEnviroment)
        {
            Configuration = configuration;
            _hostingEnviroment = hostingEnviroment;
            _uploadFolder = Configuration.GetSection("appSettings").GetSection("UploadImagesFolder").Value;
        }

        public  IConfiguration Configuration { get; set; }
        static string _uploadFolder;
        static IHostingEnvironment _hostingEnviroment;
        public string GetUnitPhysicalLocation(string requesterId, string fileName = "", string localPath = "Units/")
        {
            string path = _uploadFolder + "/" + localPath + requesterId;
            if (!string.IsNullOrEmpty(fileName))
                path += "/" + fileName;

            return Path.Combine(_hostingEnviroment.WebRootPath, path);
        }

        public void DeleteFolder(string requesterId, string fileName = "", string localPath = "Units/")
        {
            string path = _uploadFolder + "/" + localPath + requesterId;
            if (!string.IsNullOrEmpty(fileName))
                path += "/" + fileName;
            var fullPath = Path.Combine(_hostingEnviroment.WebRootPath, path);
            if (Directory.Exists(fullPath))
            {
                Directory.Delete(fullPath, true);
            }

        }



        public string GetUnitVirtualPath(string requesterId, string fileName, string localPath = "Units/")
        {
            string path = _uploadFolder + "/" + localPath + requesterId;
            if (!string.IsNullOrEmpty(fileName))
                path += "/" + fileName;
            return path;
        }

        public async Task<string> UploadFile(string folderPath, IFormFile file)
        {
            try
            {
                string thumbPath1 = folderPath + "/Thumbs1";
                string thumbPath2 = folderPath + "/Thumbs2";
                string thumbPath3 = folderPath + "/Thumbs3";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Directory.CreateDirectory(thumbPath1);
                    Directory.CreateDirectory(thumbPath2);
                    Directory.CreateDirectory(thumbPath3);
                }

                string newFilename = Guid.NewGuid() + Path.GetExtension(file.FileName);

                using (var stream = new FileStream(folderPath + "\\" + newFilename, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return newFilename;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public  bool IsImage(string file)
        {
            if (Path.GetExtension(file).ToLower() != ".jpg"
           && Path.GetExtension(file).ToLower() != ".png"
           && Path.GetExtension(file).ToLower() != ".gif"
           && Path.GetExtension(file).ToLower() != ".jpeg")
            {
                return false;
            }
            return true;
        }


    }
}
