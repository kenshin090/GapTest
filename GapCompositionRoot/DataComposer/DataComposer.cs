using GapCommon.Interfaces.Dao;
using GapDao.Access;
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
            container.RegisterType<IClientDao, ClientDao>();
            container.RegisterType<IPolicyClientDao, PolicyClientDao>();
            container.RegisterType<IPoliciesCoveragesDao, PoliciesCoveragesDao>();
            container.RegisterType<IRiskTypeDao, RiskTypeDao>();
            container.RegisterType<ICoverageTypeDao, CoverageTypeDao>();
        }
    }
}