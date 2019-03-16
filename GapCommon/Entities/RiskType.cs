using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Entities
{
    /// <summary>
    /// The risk type entity
    /// </summary>
    public class RiskType
    {
        /// <summary>
        /// The id of the risk
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the risk
        /// </summary>
        public string Name { get; set; }
    }
}