namespace GapDao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Email = c.String(),
                        LastName = c.String(),
                        Name = c.String(),
                        NUIP = c.Int(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PolicyClients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        PolicyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.Policies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoveragePeriod = c.Int(nullable: false),
                        Description = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RiskTypeId = c.Int(nullable: false),
                        StartDatePolicy = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RiskTypes", t => t.RiskTypeId, cascadeDelete: true)
                .Index(t => t.RiskTypeId);
            
            CreateTable(
                "dbo.PoliciesCoverages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoverageTypeId = c.Int(nullable: false),
                        Percentage = c.Decimal(nullable: false, precision: 10, scale: 2),
                        PolicyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoverageTypes", t => t.CoverageTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Policies", t => t.PolicyId, cascadeDelete: true)
                .Index(t => t.CoverageTypeId)
                .Index(t => t.PolicyId);
            
            CreateTable(
                "dbo.CoverageTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Coverage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RiskTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PermissionsId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Permissions", t => t.PermissionsId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PermissionsId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExpirationDate = c.DateTime(nullable: false),
                        Token = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPermissions", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserPermissions", "PermissionsId", "dbo.Permissions");
            DropForeignKey("dbo.PolicyClients", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.Policies", "RiskTypeId", "dbo.RiskTypes");
            DropForeignKey("dbo.PoliciesCoverages", "PolicyId", "dbo.Policies");
            DropForeignKey("dbo.PoliciesCoverages", "CoverageTypeId", "dbo.CoverageTypes");
            DropForeignKey("dbo.PolicyClients", "ClientId", "dbo.Clients");
            DropIndex("dbo.UserPermissions", new[] { "UserId" });
            DropIndex("dbo.UserPermissions", new[] { "PermissionsId" });
            DropIndex("dbo.PoliciesCoverages", new[] { "PolicyId" });
            DropIndex("dbo.PoliciesCoverages", new[] { "CoverageTypeId" });
            DropIndex("dbo.Policies", new[] { "RiskTypeId" });
            DropIndex("dbo.PolicyClients", new[] { "PolicyId" });
            DropIndex("dbo.PolicyClients", new[] { "ClientId" });
            DropTable("dbo.UserTokens");
            DropTable("dbo.UserPermissions");
            DropTable("dbo.Users");
            DropTable("dbo.Permissions");
            DropTable("dbo.RiskTypes");
            DropTable("dbo.CoverageTypes");
            DropTable("dbo.PoliciesCoverages");
            DropTable("dbo.Policies");
            DropTable("dbo.PolicyClients");
            DropTable("dbo.Clients");
        }
    }
}
