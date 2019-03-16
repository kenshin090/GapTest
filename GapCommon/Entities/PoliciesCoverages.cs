using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Entities
{
    /// <summary>
    /// The Policies coverages entity
    /// </summary>
    public class PoliciesCoverages
    {
        /// <summary>
        /// The type of the coverage
        /// </summary>
        public virtual CoverageType CoverageType { get; set; }

        public int CoverageTypeId { get; set; }

        /// <summary>
        /// The id of the coverage
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Percentage of the coverage
        /// </summary>
        public decimal Percentage { get; set; }

        /// <summary>
        /// The policy owner
        /// </summary>
        public int PolicyId { get; set; }
    }
}