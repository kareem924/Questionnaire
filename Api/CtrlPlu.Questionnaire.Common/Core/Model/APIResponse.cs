using System;
using System.Collections.Generic;

namespace CtrlPlu.Questionnaire.Common.Core.Model
{
    public class APIResponse
    {
        public APIResponse()
        {
            status = 200;
            message = string.Empty;
        }
        
        public APIResponse(int statusFlg)
        {
            status = 200;
            if (statusFlg == 1)
                message = "SAVE_SUCCESS";
            if (statusFlg == 2)
                message = "UPDATE_SUCCESS";
            if (statusFlg == 3)
                message = "DELETE_SUCCESS";
            if (statusFlg == 4)
                message = "CANCEL_SUCCESS";
        }

        public APIResponse(Exception ex)
        {
            errors = new
            {
                ExeptionMsg = ex.Message,
                InnerExceptionMsg = (ex.InnerException != null) ? ex.InnerException.Message : null
            };
        }

        public APIResponse(Dictionary<string, string[]> dictionary)
        {
            status = -1;
            errors = dictionary;
        }

        public int status { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public object errors { get; set; }
    }
}