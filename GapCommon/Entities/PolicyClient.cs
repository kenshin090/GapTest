using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Entities
{
    /// <summary>
    /// The policy client entity
    /// </summary>
    public class PolicyClient
    {
        /// <summary>
        /// The client
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// The client id
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// The id of policy client
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The policy
        /// </summary>
        public virtual Policy Policy { get; set; }

        /// <summary>
        /// The policy id
        /// </summary>
        public int PolicyId { get; set; }
    }
}