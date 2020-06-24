using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public class Utilities : IUtility
    {
        //testing 
        private readonly IHostingEnvironment _hostingEnvironment;

        public IConfiguration Configuration { get; set; }
        public string BaseUrl => _httpContextAccessor.HttpContext.Request.Host.ToUriComponent();
        Random r = new Random();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Utilities(IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor,
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }

        public string Hash(string clearText)
        {
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                return GetMd5Hash(md5Hash, clearText);
            }
        }

        public bool Verify(string clearText, string encryptedText)
        {
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                return VerifyMd5Hash(md5Hash, clearText, encryptedText);
            }
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public void CreateFolder(string distFl)
        {
            if (!Directory.Exists(distFl))
                Directory.CreateDirectory(distFl);
        }

        public bool RenameFile(string oldName, string newName)
        {
            return MoveFile(oldName, newName);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        string GetMd5Hash(System.Security.Cryptography.MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        bool VerifyMd5Hash(System.Security.Cryptography.MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get file containing folder
        /// </summary>
        /// <param name="fileFullPath">File path</param>
        /// <returns>string folder path</returns>
        private string GetFolder(string fileFullPath)
        {
            int indx = fileFullPath.LastIndexOf('\\');
            return fileFullPath.Substring(0, indx);
        }

        /// <summary>
        /// Move file from folder to an other
        /// </summary>
        /// <param name="sorsFl">source file</param>
        /// <param name="distFl">distination file</param>
        /// <returns>bool true if success else false</returns>
        public bool MoveFile(string sorsFl, string distFl)
        {
            try
            {
                string fldr = GetFolder(distFl);
                if (!Directory.Exists(fldr))
                    Directory.CreateDirectory(fldr);
                if (File.Exists(distFl))
                {
                    File.Delete(distFl);
                }
                File.Move(sorsFl, distFl);
                return true;
            }
            catch (Exception)
            {
                //string err = ex.Message;
                return false;
            }
        }

        public string GetConfigKeyForTokenEncrypt()
        {
            return Configuration.GetSection("Authentication").GetSection("JwtBearer").GetSection("SecurityKey").Value;
        }

        public string RandomNumber(int digits)
        {
            string st = "";

            for (int i = 0; i < digits; i++)
            {
                st += r.Next(0, 9);
            }
            return st;
        }

        public string RandomAlphabet(int numOfChars, int CapitalAndSmall = 0) //CapitalAndSmall( 0 = capital and small ,1=capital,2 =small)
        {
            string allalpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //26
            bool Case = CapitalAndSmall == 2 ? false : true;
            string st = "";

            for (int i = 0; i < numOfChars; i++)
            {

                if (Case && (CapitalAndSmall < 2))//Capital
                {
                    st += allalpha[r.Next(0, 25)].ToString().ToUpper();
                }
                else  //Small
                {
                    st += allalpha[r.Next(0, 25)].ToString().ToLower();
                }
                if (CapitalAndSmall == 0)
                    Case = !Case;
            }
            return st;
        }

        public string Base64ToImage(string base64String, string module, string name)
        {
            if (string.IsNullOrEmpty(base64String)) return null;
            string imageURL = null;
            string ext = GetFilenameExtension(base64String);
            int idx = base64String.LastIndexOf(',');
            base64String = base64String.Remove(0, idx + 1);
            byte[] imageBytes = Convert.FromBase64String(base64String);
            name += ext;
            using (var imageFile = new FileStream(GetFilePath(module, name, ref imageURL), FileMode.Create))
            {
                imageFile.Write(imageBytes, 0, imageBytes.Length);
                imageFile.Flush();
                imageFile.Dispose();
            }

            return (imageURL + name);
        }

        private string GetFilePath(string module, string fileName, ref string uploadFolder)
        {
            uploadFolder = string.Format("Uploads/{0}/", module);

            var webRoot = _hostingEnvironment.WebRootPath;
            var dir = System.IO.Path.Combine(webRoot, uploadFolder).Normalize();
            // you could put this to web.config
            Directory.CreateDirectory(dir);
            string path = System.IO.Path.Combine(dir, fileName).Normalize();

            return path;
        }
        public bool IsBase64(string base64String)
        {
            if (base64String == null || base64String.Length == 0)
                return false;

            base64String = Base64RemovePrefx(base64String);

            // Credit: oybek https://stackoverflow.com/users/794764/oybek
            if (base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {

                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception exception)
            {
                // Handle the exception
            }
            return false;
        }

        private string Base64RemovePrefx(string base64String)
        {
            string rslt = string.Empty;
            try
            {
                var index = base64String.IndexOf(",");
                if (index > 0)
                {
                    string prfx = base64String.Substring(0, index + 1);
                    rslt = base64String.Replace(prfx, "");
                }
                else
                    rslt = "Error";
            }
            catch (Exception ex)
            {
                rslt = "Error";
            }

            return rslt;
        }
        public bool IsImage(string file)
        {
            if (string.IsNullOrEmpty(file))
                return false;
            if (Path.GetExtension(file).ToLower() != ".jpg"
           && Path.GetExtension(file).ToLower() != ".png"
           && Path.GetExtension(file).ToLower() != ".gif"
           && Path.GetExtension(file).ToLower() != ".bmp"
           && Path.GetExtension(file).ToLower() != ".tif"
           && Path.GetExtension(file).ToLower() != ".jpeg"
           && Path.GetExtension(file).ToLower() != ".pdf")
            {
                return false;
            }
            return true;
        }

        private string GetFilenameExtension(string base64String)
        {
            int idx = base64String.LastIndexOf(',');
            string extdata = base64String.Substring(0, idx);
            string ext = string.Empty;

            if (extdata.ToLower().Contains("openxmlformats"))
                ext = ".xlxs";
            else if (extdata.ToLower().Contains("jpeg"))
                return ".jpeg";
            else if (extdata.ToLower().Contains("png"))
                return ".png";
            else if (extdata.ToLower().Contains("bmp"))
                return ".bmp";
            else if (extdata.ToLower().Contains("tif"))
                return ".tif";
            else if (extdata.ToLower().Contains("gif"))
                return ".gif";
            else if (extdata.ToLower().Contains("pdf"))
                return ".pdf";
            else
                return ".jpg";
            return ext;
        }

        public string GetFileFullURL(string fileRelativePath)
        {
            return string.Concat("http://", BaseUrl, '/', fileRelativePath);
        }
        public string RemoveBaseUrl(string fileRelativePath)
        {
            return fileRelativePath.Replace("http://" + BaseUrl + "/", "");
        }

        /// <summary>
        /// A price converter
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public string GetRootPath()
        {
            return _hostingEnvironment.WebRootPath;
        }

        public string GetBaseCurrUrl()
        {

            var path = Configuration["BaseCurrRateUrl"];
            return path;
        }

        public string EmptyIfNull(string text)
        {
            return string.IsNullOrEmpty(text) ? string.Empty : text;
        }
        /*
        public string GetResValue(string resKey, string lang)
        {
            try
            {
                string path = $@"{GetRootPath()}\Res\{lang}.json";
                string fileContnt = System.IO.File.ReadAllText(path);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(fileContnt);
                string rslt = (string)jsonObj[resKey];
                return string.IsNullOrEmpty(rslt) ? resKey : rslt;
            }
            catch (Exception ex)
            {
                return resKey;
            }
        }
        */
        public static string FormatDateForDB(DateTime dateTime)
        {
            return $"{dateTime.Year}.{dateTime.Month}.{dateTime.Day}T{dateTime.Hour}.{dateTime.Minute}.{dateTime.Second}";
        }
    }
}