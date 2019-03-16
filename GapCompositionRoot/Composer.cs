using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GapCompositionRoot
{
    /// <summary>
    /// Class for build the unity container
    /// </summary>
    public static class Composer
    {
        /// <summary>
        /// Method to add registers
        /// </summary>
        /// <returns></returns>
        public static UnityContainer BuildContainer()
        {
            var container = new UnityContainer();
            BussinessComposer.BussinessComposer.Compose(container);
            DataComposer.DataComposer.Compose(container);
            return container;
        }
    }
}