namespace Vigil
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VigilRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.VigilUserRole",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.VigilRole", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.VigilUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.VigilUser",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.VigilUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VigilUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.VigilUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.VigilUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VigilUserRole", "UserId", "dbo.VigilUser");
            DropForeignKey("dbo.VigilUserLogin", "UserId", "dbo.VigilUser");
            DropForeignKey("dbo.VigilUserClaim", "UserId", "dbo.VigilUser");
            DropForeignKey("dbo.VigilUserRole", "RoleId", "dbo.VigilRole");
            DropIndex("dbo.VigilUserLogin", new[] { "UserId" });
            DropIndex("dbo.VigilUserClaim", new[] { "UserId" });
            DropIndex("dbo.VigilUser", "UserNameIndex");
            DropIndex("dbo.VigilUserRole", new[] { "RoleId" });
            DropIndex("dbo.VigilUserRole", new[] { "UserId" });
            DropIndex("dbo.VigilRole", "RoleNameIndex");
            DropTable("dbo.VigilUserLogin");
            DropTable("dbo.VigilUserClaim");
            DropTable("dbo.VigilUser");
            DropTable("dbo.VigilUserRole");
            DropTable("dbo.VigilRole");
        }
    }
}
