using GapCommon.Entities;
using GapCommon.Interfaces.Bll;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GapServices.Controllers
{
    public class UserController : BaseApiController
    {
        private IUsers Module = null;

        /// <summary>
        /// builder for injection
        /// </summary>
        /// <param name="module"></param>
        public UserController(IUsers module)
        {
            this.Module = module;
        }

        /// <summary>
        /// Method to delete a User
        /// </summary>
        /// <param name="id">UserId</param>
        [Authorize(Roles = "Administrator")]
        public void Delete(int id)
        {
            Module.Delete(id);
        }

        /// <summary>
        /// Method to get all the Users
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public IEnumerable<User> Get()
        {
            Expression<Func<User, bool>> expression = (pl => pl.Id != 0);
            return Module.Search(expression, 1, int.MaxValue);
        }

        /// <summary>
        /// Method to return an specific User
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>persisted User</returns>
        [SwaggerOperation("GetUserById")]
        [Authorize(Roles = "Administrator")]
        public User Get(int id)
        {
            return Module.Get(id);
        }

        /// <summary>
        /// Method to create a new User
        /// </summary>
        /// <param name="value">the new User</param>
        /// <returns>persisted User</returns>
        public User Post([FromBody]User value)
        {
            return Module.Create(value);
        }

        /// <summary>
        /// Method to update a persisted User
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="value">the updated User</param>
        /// <returns>persited User</returns>
        [Authorize(Roles = "Administrator")]
        public User Put(int id, [FromBody]User value)
        {
            return Module.Update(id, value);
        }
    }
}