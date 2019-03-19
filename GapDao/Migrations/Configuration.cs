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

            IList<Permissions> defatultPermissions = new List<Permissions>();
            defatultPermissions.Add(new Permissions() { Name = "Administrator" });
            defatultPermissions.Add(new Permissions() { Name = "Client" });

            context.Permissions.AddRange(defatultPermissions);

            IList<User> defatultUsers = new List<User>();

            List<UserPermission> adminPermission = new List<UserPermission>();
            adminPermission.Add(new UserPermission() { PermissionsId = 1 });

            defatultUsers.Add(new User() { CreatedDate = DateTime.Now, Email = "Admin@gap.com", Password = "123456", Permissions = adminPermission });

            context.User.AddRange(defatultUsers);
        }
    }
}