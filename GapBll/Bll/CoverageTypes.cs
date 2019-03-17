using GapCommon.Entities;
using GapCommon.Interfaces.Bll;
using GapCommon.Interfaces.Dao;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GapBll.Bll
{
    /// <summary>
    /// The context of CoverageTypes
    /// </summary>
    public class CoverageTypes : ICoverageTypes
    {
        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">access to table CoverageType</param>
        public CoverageTypes(ICoverageTypeDao module)
        {
            this.Module = module;
        }

        public ICoverageTypeDao Module { get; set; }

        /// <summary>
        /// Method to create a new CoverageType
        /// </summary>
        /// <param name="entity">the new CoverageType</param>
        /// <returns>persisted CoverageType</returns>
        public CoverageType Create(CoverageType entity)
        {
            return Module.Create(entity);
        }

        /// <summary>
        /// Method to delete a CoverageType
        /// </summary>
        /// <param name="id">CoverageType id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            return Module.Delete(id);
        }

        /// <summary>
        /// Method for return a specific CoverageType
        /// </summary>
        /// <param name="Id">the id of the CoverageType</param>
        /// <returns>Persisted CoverageType</returns>
        public CoverageType Get(int id)
        {
            return Module.Get(id);
        }

        /// <summary>
        /// Method for search a CoverageTypes list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of CoverageTypes that match with the expression</returns>
        public List<CoverageType> Search(Expression<Func<CoverageType, bool>> expression, int page = 1, int size = 10)
        {
            return Module.Search(expression, page, size);
        }

        /// <summary>
        /// Method for update a CoverageType
        /// </summary>
        /// <param name="id">the id of the CoverageType</param>
        /// <param name="entity">the entity CoverageType</param>
        /// <returns>the CoverageType persisted</returns>
        public CoverageType Update(int idEntity, CoverageType Entity)
        {
            return Module.Update(idEntity, Entity);
        }
    }
}