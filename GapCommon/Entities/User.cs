using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Entities
{
    /// <summary>
    /// The user entity
    /// </summary>
    public class User
    {
        /// <summary>
        /// Created date user
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The email user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The id of the user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The password user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The permissions of user
        /// </summary>
        public virtual List<UserPermission> Permissions { get; set; }
    }
}