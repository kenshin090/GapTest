using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Entities
{
    /// <summary>
    /// The Policy entity
    /// </summary>
    public class Policy
    {
        /// <summary>
        /// Total of months of coverage period
        /// </summary>
        public int CoveragePeriod { get; set; }

        /// <summary>
        /// Type of coverages in the policy
        /// </summary>
        public virtual List<PoliciesCoverages> Coverages { get; set; }

        /// <summary>
        /// Description of the policy
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The id of the policy
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the policy
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of the policy
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// The risk type of the policy
        /// </summary>
        public virtual RiskType RiskType { get; set; }

        public int RiskTypeId { get; set; }

        public DateTime StartDatePolicy { get; set; }
    }
}