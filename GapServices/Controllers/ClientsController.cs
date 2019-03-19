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
    /// Clients controller
    /// </summary>
    public class ClientsController : BaseApiController
    {
        private IClients Module = null;

        /// <summary>
        /// builder for injection
        /// </summary>
        /// <param name="module"></param>
        public ClientsController(IClients module)
        {
            this.Module = module;
        }

        /// <summary>
        /// Method to delete a Client
        /// </summary>
        /// <param name="id">ClientId</param>
        [Authorize(Roles = "Administrator")]
        public void Delete(int id)
        {
            Module.Delete(id);
        }

        /// <summary>
        /// Method to get all the Clients
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public IEnumerable<Client> Get()
        {
            Expression<Func<Client, bool>> expression = (pl => pl.Id != 0);
            return Module.Search(expression, 1, int.MaxValue);
        }

        /// <summary>
        /// Method to return an specific Client
        /// </summary>
        /// <param name="id">Client id</param>
        /// <returns>persisted Client</returns>
        [SwaggerOperation("GetClientById")]
        [Authorize(Roles = "Administrator")]
        public Client Get(int id)
        {
            return Module.Get(id);
        }

        /// <summary>
        /// Method to create a new Client
        /// </summary>
        /// <param name="value">the new Client</param>
        /// <returns>persisted Client</returns>
        [Authorize(Roles = "Administrator")]
        public Client Post([FromBody]Client value)
        {
            return Module.Create(value);
        }

        /// <summary>
        /// Method to update a persisted Client
        /// </summary>
        /// <param name="id">Client id</param>
        /// <param name="value">the updated Client</param>
        /// <returns>persited Client</returns>
        [Authorize(Roles = "Administrator")]
        public Client Put(int id, [FromBody]Client value)
        {
            return Module.Update(id, value);
        }
    }
}