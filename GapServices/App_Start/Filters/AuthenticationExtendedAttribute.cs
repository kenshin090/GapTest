using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace GapServices.App_Start.Filters
{
    /// <summary>
    /// Filter to manage the roles of the user
    /// </summary>
    public class AuthenticationExtendedAttribute : Attribute, IAuthenticationFilter
    {
        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">the access to the authentication</param>
        public AuthenticationExtendedAttribute()
        {
        }

        /// <summary>
        ///
        /// </summary>
        public bool AllowMultiple => false;

        /// <summary>
        /// task for define the role
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            List<Claim> claims = new List<Claim>();

            if (HttpContext.Current.Request.Headers["Ocp-Apim-Subscription-Key"] != null)
            {
                if (HttpContext.Current.Request.Headers["Ocp-Apim-Subscription-Key"]
                    == System.Configuration.ConfigurationManager.AppSettings["ApiSecuredKey"])
                {
                    DefineRoles(claims);
                }
            }

            ClaimsIdentity identity = new ClaimsIdentity(claims, "none");
            context.Principal = new ClaimsPrincipal(new[] { identity });
            return;
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return;
        }

        private void DefineRoles(List<Claim> claims)
        {
            if (HttpContext.Current.Request.Headers["TokenId"] != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Client"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "Invited"));
            }

            if (HttpContext.Current.Request.Headers["Secret"] != null)
            {
            }
        }
    }
}