using System.Security.Claims;

namespace CtrlPlu.Questionnaire.Common.Context
{
    public class ContextUser : ClaimsPrincipal
    {
        public ContextUser(ContextUser reqUser)
        {
            if (reqUser != null)
            {
                Id = reqUser.Id;
                Name = reqUser.Name;
                IsAuthenticated = reqUser.IsAuthenticated;
                IssuedOn = reqUser.IssuedOn;
                ExpiresOn = reqUser.ExpiresOn;
            }
        }
        public ContextUser()
        {
            //To-Do:localized value of gest
            Name = "Guest";
            IsAuthenticated = false;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsAuthenticated { get; set; }

        public string AuthenticationType { get { return "Bearer"; } }

        public long IssuedOn { get; set; }

        public long ExpiresOn { get; set; }
    }
}
