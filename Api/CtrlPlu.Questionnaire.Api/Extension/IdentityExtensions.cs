using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CtrlPlu.Questionnaire.Api.Extension
{
    public static class IdentityExtensions
    {
        //public static string GetUserProperty(this IIdentity identity, string value)
        //{
        //    var claim = ((ClaimsIdentity)identity).FindFirst(value);

        //    return claim == null ? null : claim.Value;
        //}
        //public static List<string> GetPermissions(this IIdentity identity) => ((ClaimsIdentity)identity).Permissions();
        public static List<string> Roles(this ClaimsIdentity identity) => identity.Claims
                   .Where(c => c.Type == ClaimTypes.Role)
                   .Select(c => c.Value)
                   .ToList();
       
  

        // Identities
        public static string GetUserProperty(this IEnumerable<ClaimsIdentity> identities, string value)
        {
            var claim = ((IEnumerable<ClaimsIdentity>)identities).SelectMany(x => x.Claims)
                .FirstOrDefault(x => x.Type == value);

            return claim?.Value;
        }
        
    }

    public class UserProperties
    {
        public int Id { get; set; }
    }
}
