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
    /// The context of PolicyClients
    /// </summary>
    public class PolicyClients : IPolicyClients
    {
        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">access to table client</param>
        public PolicyClients(IPolicyClientDao module)
        {
            this.Module = module;
        }

        public IPolicyClientDao Module { get; set; }

        /// <summary>
        /// Method to create a new PolicyClient
        /// </summary>
        /// <param name="entity">the new PolicyClient</param>
        /// <returns>persisted PolicyClient</returns>
        public PolicyClient Create(PolicyClient entity)
        {
            return Module.Create(entity);
        }

        /// <summary>
        /// Method to delete a PolicyClient
        /// </summary>
        /// <param name="id">PolicyClient id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            return Module.Delete(id);
        }

        /// <summary>
        /// Method for return a specific PolicyClient
        /// </summary>
        /// <param name="Id">the id of the PolicyClient</param>
        /// <returns>Persisted PolicyClient</returns>
        public PolicyClient Get(int id)
        {
            return Module.Get(id);
        }

        /// <summary>
        /// Method for search a PolicyClients list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of PolicyClients that match with the expression</returns>
        public List<PolicyClient> Search(Expression<Func<PolicyClient, bool>> expression, int page = 1, int size = 10)
        {
            return Module.Search(expression, page, size);
        }

        /// <summary>
        /// Method for update a PolicyClient
        /// </summary>
        /// <param name="id">the id of the PolicyClient</param>
        /// <param name="entity">the entity PolicyClient</param>
        /// <returns>the PolicyClient persisted</returns>
        public PolicyClient Update(int idEntity, PolicyClient Entity)
        {
            return Module.Update(idEntity, Entity);
        }
    }
}