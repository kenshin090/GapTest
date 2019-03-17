using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Entities
{
    /// <summary>
    /// The client entity
    /// </summary>
    public class Client
    {
        /// <summary>
        /// The address of the client
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// The email of client
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The client id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The lastname of client
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The name of client
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The NUIP of client
        /// </summary>
        public int NUIP { get; set; }

        /// <summary>
        /// The phone number of client
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The policies of client
        /// </summary>
        public virtual List<PolicyClient> Policies { get; set; }
    }
}