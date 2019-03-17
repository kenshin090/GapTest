using GapCommon.Entities;
using GapCommon.Interfaces.Bll;
using GapCommon.Interfaces.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GapBll.Bll
{
    /// <summary>
    /// The context of clients
    /// </summary>
    public class Clients : IClients
    {
        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">access to table client</param>
        public Clients(IClientDao module)
        {
            this.Module = module;
        }

        public IClientDao Module { get; set; }

        /// <summary>
        /// Method to create a new client
        /// </summary>
        /// <param name="entity">the new client</param>
        /// <returns>persisted client</returns>
        public Client Create(Client entity)
        {
            return Module.Create(entity);
        }

        /// <summary>
        /// Method to delete a client
        /// </summary>
        /// <param name="id">client id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            return Module.Delete(id);
        }

        /// <summary>
        /// Method for return a specific client
        /// </summary>
        /// <param name="Id">the id of the client</param>
        /// <returns>Persisted client</returns>
        public Client Get(int id)
        {
            return Module.Get(id);
        }

        /// <summary>
        /// Method for search a clients list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of clients that match with the expression</returns>
        public List<Client> Search(Expression<Func<Client, bool>> expression, int page = 1, int size = 10)
        {
            return Module.Search(expression, page, size);
        }

        /// <summary>
        /// Method for update a client
        /// </summary>
        /// <param name="id">the id of the client</param>
        /// <param name="entity">the entity client</param>
        /// <returns>the client persisted</returns>
        public Client Update(int idEntity, Client Entity)
        {
            return Module.Update(idEntity, Entity);
        }
    }
}