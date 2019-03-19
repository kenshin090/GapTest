using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Entities
{
    /// <summary>
    /// The token entity
    /// </summary>
    public class UserToken
    {
        /// <summary>
        /// Date valid of the token
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// The id of the token
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The owner of token
        /// </summary>
        public int UserId { get; set; }
    }
}