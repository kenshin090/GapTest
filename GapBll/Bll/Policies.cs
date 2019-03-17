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
    public class Policies : IPolicies
    {
        /// <summary>
        /// Builder for the injection
        /// </summary>
        /// <param name="module">access to table PoliciesCoverages</param>
        public Policies(IPolicyDao module)
        {
            this.Module = module;
        }

        private IPolicyDao Module { get; set; }

        public Policy Create(Policy entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Policy Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Policy> Search(Expression<Func<Policy, bool>> expression, int page = 1, int size = 10)
        {
            throw new NotImplementedException();
        }

        public Policy Update(int idEntity, Policy Entity)
        {
            throw new NotImplementedException();
        }
    }
}