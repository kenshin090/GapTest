using GapCommon.Entities;
using GapCommon.Exceptions;
using GapCommon.Interfaces.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        private IUserTokens ModuleTokens = null;

        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">the access to the authentication</param>
        public AuthenticationExtendedAttribute(IUserTokens moduleTokens)
        {
            this.ModuleTokens = moduleTokens;
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
            if (HttpContext.Current.Request.Headers["Authorization"] != null)
            {
                string Token = HttpContext.Current.Request.Headers["Authorization"];
                ValidateToken(Token, context);
            }
            else
            {
                context.ActionContext.ControllerContext.RouteData.Values.Add("LoadPermission", false);
            }

            return;
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return;
        }

        private void ValidateToken(string token, HttpAuthenticationContext context)
        {
            Expression<Func<UserToken, bool>> expression = (usrT => usrT.Token == token);
            UserToken persisted = ModuleTokens.Search(expression).FirstOrDefault();
            if (persisted != null && persisted.ExpirationDate > DateTime.Now)
            {
                context.ActionContext.ControllerContext.RouteData.Values.Add("LoadPermission", true);
                context.ActionContext.ControllerContext.RouteData.Values.Add("UserId", persisted.UserId);
            }
            else
            {
                throw new MessageException() { Code = -1, TextMessage = "InvalidToken" };
            }
        }
    }
}