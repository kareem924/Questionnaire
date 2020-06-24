using Microsoft.AspNetCore.Http;

namespace CtrlPlu.Questionnaire.Common.Context
{
    public class WorkContext : IWorkContext
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public WorkContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ContextUser User => new ContextUser(_httpContextAccessor.HttpContext.User as ContextUser);

        public string Lang
        {
            get
            {
                try
                {
                    if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request?.Headers?["Accept-Language"].ToString()))
                        return _httpContextAccessor.HttpContext.Request?.Headers?["Accept-Language"];
                    else
                        return "ar-EG";
                }
                catch (System.Exception)
                {
                    return "ar-EG";
                }
            }
        }

    }
}
