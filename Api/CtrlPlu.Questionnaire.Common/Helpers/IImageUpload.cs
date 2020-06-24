using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public interface IImageUpload
    {
        string GetUnitPhysicalLocation(string requesterId, string fileName, string localPath);
        void DeleteFolder(string requesterId, string fileName, string localPath);
        string GetUnitVirtualPath(string requesterId, string fileName, string localPath);
        Task<string> UploadFile(string folderPath, IFormFile file);
    }
}
