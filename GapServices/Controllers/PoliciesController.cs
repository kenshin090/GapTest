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
    /// <summary>
    /// The policies controller
    /// </summary>
    public class PoliciesController : BaseApiController
    {
        private IPolicies Module = null;

        /// <summary>
        /// builder for injection
        /// </summary>
        /// <param name="module"></param>
        public PoliciesController(IPolicies module)
        {
            this.Module = module;
        }

        /// <summary>
        /// Method to delete a policy
        /// </summary>
        /// <param name="id">PolicyId</param>
        [Authorize(Roles = "Administrator")]
        public void Delete(int id)
        {
            Module.Delete(id);
        }

        /// <summary>
        /// Method to get all the policies
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public IEnumerable<Policy> Get()
        {
            Expression<Func<Policy, bool>> expression = (pl => pl.Id != 0);
            return Module.Search(expression, 1, int.MaxValue);
        }

        /// <summary>
        /// Method to return an specific policy
        /// </summary>
        /// <param name="id">policy id</param>
        /// <returns>persisted policy</returns>
        [SwaggerOperation("GetPolicyById")]
        [Authorize(Roles = "Administrator")]
        public Policy Get(int id)
        {
            return Module.Get(id);
        }

        /// <summary>
        /// Method to create a new policy
        /// </summary>
        /// <param name="value">the new policy</param>
        /// <returns>persisted policy</returns>
        [Authorize(Roles = "Administrator")]
        public Policy Post([FromBody]Policy value)
        {
            return Module.Create(value);
        }

        /// <summary>
        /// Method to update a persisted policy
        /// </summary>
        /// <param name="id">policy id</param>
        /// <param name="value">the updated policy</param>
        /// <returns>persited policy</returns>
        [Authorize(Roles = "Administrator")]
        public Policy Put(int id, [FromBody]Policy value)
        {
            return Module.Update(id, value);
        }
    }
}