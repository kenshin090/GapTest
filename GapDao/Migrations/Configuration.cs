namespace GapDao.Migrations
{
    using GapCommon.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GapDao.Contexts.GapContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GapDao.Contexts.GapContext context)
        {
            IList<RiskType> defaultRisk = new List<RiskType>();
            defaultRisk.Add(new RiskType() { Name = "Bajo" });
            defaultRisk.Add(new RiskType() { Name = "Medio" });
            defaultRisk.Add(new RiskType() { Name = "Medio-Alto" });
            defaultRisk.Add(new RiskType() { Name = "Alto" });

            context.RiskType.AddRange(defaultRisk);

            IList<CoverageType> defaultCoverageType = new List<CoverageType>();
            defaultCoverageType.Add(new CoverageType() { Coverage = "Terremoto" });
            defaultCoverageType.Add(new CoverageType() { Coverage = "Incendio" });
            defaultCoverageType.Add(new CoverageType() { Coverage = "Perdida" });
            defaultCoverageType.Add(new CoverageType() { Coverage = "Hurto" });

            context.CoverageType.AddRange(defaultCoverageType);
        }
    }
}