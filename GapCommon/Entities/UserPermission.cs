using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Entities
{
    public class UserPermission
    {
        public int Id { get; set; }
        public virtual Permissions Permissions { get; set; }
        public int PermissionsId { get; set; }
        public int UserId { get; set; }
    }
}