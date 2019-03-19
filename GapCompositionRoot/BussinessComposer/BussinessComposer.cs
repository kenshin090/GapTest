using AutoMapper;
using GapBll.Bll;
using GapBll.Bll.PoliciesCoverages;
using GapCommon.Interfaces.Bll;
using GapCommon.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GapCompositionRoot.BussinessComposer
{
    /// <summary>
    /// Class to add register of the bussiness access
    /// </summary>
    public static class BussinessComposer
    {
        /// <summary>
        ///  Method to add the registers
        /// </summary>
        /// <param name="container">the app container</param>
        public static void Compose(UnityContainer container)
        {
            ///mapping
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperBootstrap());
            });

            container.RegisterInstance<IMapper>(config.CreateMapper());
            container.RegisterType<IPolicies, Policies>();
            container.RegisterType<IClients, Clients>();
            container.RegisterType<ICoverageTypes, CoverageTypes>();
            container.RegisterType<IPoliciesCoverages, PoliciesCoverages>();
            container.RegisterType<IPolicyClients, PolicyClients>();
            container.RegisterType<IRiskTypes, RiskTypes>();
            container.RegisterType<IUsers, Users>();
            container.RegisterType<IUserTokens, UserTokens>();
        }
    }
}