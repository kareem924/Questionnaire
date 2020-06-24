using System;
using CtrlPlu.Questionnaire.Common.Context;
using Newtonsoft.Json;

namespace CtrlPlu.Questionnaire.Common.Helpers
{
    public class Localizer : ILocalizer
    {
        private readonly IUtility _utility;

        public readonly IWorkContext _workContext;

        private readonly IMSMemoryCash _memoryCash;

        private const string cashKey = "cash_{0}_{1}";
        public Localizer(IUtility utility, IWorkContext workContext, IMSMemoryCash memoryCash)
        {
            _utility = utility;
            _workContext = workContext;
            _memoryCash = memoryCash;
        }

        public string GetLocalized(string resKey, string moduleName)
        {
            string value = resKey;

            dynamic obj = _memoryCash.GetCashItem(GetCashingKey(moduleName));

            if (obj != null)
            {
                value = (string)obj[resKey];
            }
            else
            {
                try
                {
                    dynamic jsonObj = ReadFromResFile(moduleName);
                    value = (string)jsonObj[resKey];
                }
                catch (Exception ex)
                {
                    // TO-DO : Add logging
                }
            }
            return value;
        }

        private string GetCashingKey(string moduleName)
        {
            return string.Format(cashKey, moduleName, _workContext.Lang);
        }

        private dynamic ReadFromResFile(string moduleName)
        {
            string path = $@"{_utility.GetRootPath()}\Res\{GetCashingKey(moduleName)}.json";
            string fileContnt = System.IO.File.ReadAllText(path);
            dynamic jsonObj = JsonConvert.DeserializeObject(fileContnt);
            _memoryCash.CashItem(GetCashingKey(moduleName), jsonObj);
            return jsonObj;
        }
    }
}
