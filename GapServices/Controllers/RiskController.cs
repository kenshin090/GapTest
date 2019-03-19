using GapCommon.Entities;
using GapCommon.Interfaces.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GapServices.Controllers
{
    public class RiskController : BaseApiController
    {
        private IRiskTypes Module = null;

        /// <summary>
        /// builder for injection
        /// </summary>
        /// <param name="module"></param>
        public RiskController(IRiskTypes module)
        {
            this.Module = module;
        }

        /// <summary>
        /// Method to get all the risks
        /// </summary>
        /// <returns>persisted coverages</returns>
        [Authorize(Roles = "Administrator")]
        public IEnumerable<RiskType> Get()
        {
            Expression<Func<RiskType, bool>> expression = (pl => pl.Id != 0);
            return Module.Search(expression, 1, int.MaxValue);
        }
    }
}