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
    /// The context of Risk Types
    /// </summary>
    public class RiskTypes : IRiskTypes
    {
        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">access to table client</param>
        public RiskTypes(IRiskTypeDao module)
        {
            this.Module = module;
        }

        public IRiskTypeDao Module { get; set; }

        /// <summary>
        /// Method to create a new RiskType
        /// </summary>
        /// <param name="entity">the new RiskType</param>
        /// <returns>persisted RiskType</returns>
        public RiskType Create(RiskType entity)
        {
            return Module.Create(entity);
        }

        /// <summary>
        /// Method to delete a RiskType
        /// </summary>
        /// <param name="id">RiskType id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            return Module.Delete(id);
        }

        /// <summary>
        /// Method for return a specific RiskType
        /// </summary>
        /// <param name="Id">the id of the RiskType</param>
        /// <returns>Persisted RiskType</returns>
        public RiskType Get(int id)
        {
            return Module.Get(id);
        }

        /// <summary>
        /// Method for search a RiskTypes list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of RiskTypes that match with the expression</returns>
        public List<RiskType> Search(Expression<Func<RiskType, bool>> expression, int page = 1, int size = 10)
        {
            return Module.Search(expression, page, size);
        }

        /// <summary>
        /// Method for update a RiskType
        /// </summary>
        /// <param name="id">the id of the RiskType</param>
        /// <param name="entity">the entity RiskType</param>
        /// <returns>the RiskType persisted</returns>
        public RiskType Update(int idEntity, RiskType Entity)
        {
            return Module.Update(idEntity, Entity);
        }
    }
}