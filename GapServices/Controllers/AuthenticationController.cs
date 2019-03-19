using GapCommon.Entities;
using GapCommon.Interfaces.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GapServices.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private IUsers Module = null;

        /// <summary>
        /// builder for injection
        /// </summary>
        /// <param name="module"></param>
        public AuthenticationController(IUsers module)
        {
            this.Module = module;
        }

        /// <summary>
        /// Method to generate a new token
        /// </summary>
        /// <param name="value"></param>
        public UserToken Post([FromBody]User user)
        {
            return Module.LogIn(user);
        }
    }
}