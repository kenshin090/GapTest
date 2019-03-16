using GapCommon.Interfaces.Dao;
using GapDao.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GapCompositionRoot.DataComposer
{
    /// <summary>
    /// Class to add register of the data access
    /// </summary>
    public static class DataComposer
    {
        /// <summary>
        /// Method to add the registers
        /// </summary>
        /// <param name="container"></param>
        public static void Compose(UnityContainer container)
        {
            container.RegisterType<IPolicyDao, PolicyDao>();
        }
    }
}