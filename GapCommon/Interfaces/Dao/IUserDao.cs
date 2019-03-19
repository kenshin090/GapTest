using GapCommon.Entities;
using GapCommon.Interfaces.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapCommon.Interfaces.Dao
{
    public interface IUserDao : IRepository<User>
    {
    }
}