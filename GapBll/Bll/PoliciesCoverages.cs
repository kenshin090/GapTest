using GapCommon.Interfaces.Bll;
using GapCommon.Interfaces.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GapBll.Bll.PoliciesCoverages
{
    /// <summary>
    /// The context of policies coverages
    /// </summary>
    public class PoliciesCoverages : IPoliciesCoverages
    {
        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">access to table PoliciesCoverages</param>
        public PoliciesCoverages(IPoliciesCoveragesDao module)
        {
            this.Module = module;
        }

        public IPoliciesCoveragesDao Module { get; set; }

        /// <summary>
        /// Method to create a new PoliciesCoverages
        /// </summary>
        /// <param name="entity">the new PoliciesCoverages</param>
        /// <returns>persisted PoliciesCoverages</returns>
        public GapCommon.Entities.PoliciesCoverages Create(GapCommon.Entities.PoliciesCoverages entity)
        {
            return Module.Create(entity);
        }

        /// <summary>
        /// Method to delete a PoliciesCoverages
        /// </summary>
        /// <param name="id">PoliciesCoverages id</param>
        /// <returns>rows afected</returns>
        public int Delete(int id)
        {
            return Module.Delete(id);
        }

        /// <summary>
        /// Method for return a specific PoliciesCoverages
        /// </summary>
        /// <param name="Id">the id of the PoliciesCoverages</param>
        /// <returns>Persisted PoliciesCoverages</returns>
        public GapCommon.Entities.PoliciesCoverages Get(int id)
        {
            return Module.Get(id);
        }

        /// <summary>
        /// Method for search a PoliciesCoveragess list
        /// </summary>
        /// <param name="expression">the expression for search(lambda expression)</param>
        /// <param name="page">page needed</param>
        /// <param name="size">size of every page</param>
        /// <returns>a list of PoliciesCoveragess that match with the expression</returns>
        public List<GapCommon.Entities.PoliciesCoverages> Search(Expression<Func<GapCommon.Entities.PoliciesCoverages, bool>> expression, int page = 1, int size = 10)
        {
            return Module.Search(expression, page, size);
        }

        /// <summary>
        /// Method for update a PoliciesCoverages
        /// </summary>
        /// <param name="id">the id of the PoliciesCoverages</param>
        /// <param name="entity">the entity PoliciesCoverages</param>
        /// <returns>the PoliciesCoverages persisted</returns>
        public GapCommon.Entities.PoliciesCoverages Update(int idEntity, GapCommon.Entities.PoliciesCoverages Entity)
        {
            return Module.Update(idEntity, Entity);
        }
    }
}