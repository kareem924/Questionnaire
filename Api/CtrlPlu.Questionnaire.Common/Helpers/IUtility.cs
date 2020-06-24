namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public interface IUtility
    {
        string GetConfigKeyForTokenEncrypt();
        string Hash(string clearText);
        string BaseUrl { get; }
        string RandomNumber(int digits);
        string RandomAlphabet(int numOfChars, int CapitalAndSmall = 0);
        bool Verify(string clearText, string encryptedText);
        bool IsImage(string file);
        string Base64ToImage(string base64String, string module, string name);
        string GetFileFullURL(string profilePic);
        string RemoveBaseUrl(string profilePic);
        string GetRootPath();
        string GetBaseCurrUrl();
        string EmptyIfNull(string text);
        bool IsBase64(string base64String);
        //string GetResValue(string resKey, string lang);
    }
}