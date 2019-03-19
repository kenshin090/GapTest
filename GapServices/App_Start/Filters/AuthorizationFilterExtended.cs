using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using GapCommon.Entities;
using GapCommon.Interfaces.Bll;

namespace GapServices.App_Start.Filters
{
    public class AuthorizationFilterExtended : IAuthorizationFilter
    {
        private IUsers users;

        public AuthorizationFilterExtended(IUsers users)
        {
            this.users = users;
        }

        public bool AllowMultiple => false;

        public Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            string unAuth = actionContext.ControllerContext.RouteData.Values["LoadPermission"].ToString();
            bool LoadPermissions = false;
            bool.TryParse(unAuth, out LoadPermissions);
            if (LoadPermissions)
            {
                int userId = 0;
                int.TryParse(actionContext.ControllerContext.RouteData.Values["UserId"].ToString(), out userId);
                List<Claim> claims = new List<Claim>();
                DefineRoles(claims, userId);
                InpersonateUser(claims);
            }

            return continuation();
        }

        private static void InpersonateUser(List<Claim> claims)
        {
            ClaimsIdentity identity = new ClaimsIdentity(claims, "none");
            ClaimsPrincipal principal = new ClaimsPrincipal(new[] { identity });
            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
        }

        private void DefineRoles(List<Claim> claims, int userId)
        {
            User user = users.Get(userId);
            foreach (var item in user.Permissions)
            {
                switch (item.Permissions.Name.ToLower())
                {
                    case "administrator":
                        claims.Add(new Claim(ClaimTypes.Role, "Administrator"));
                        break;

                    case "client":
                        claims.Add(new Claim(ClaimTypes.Role, "Client"));
                        break;

                    default:
                        break;
                }
            }
        }
    }
}