namespace InstaSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SportsAndLocationsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Latitite = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CityId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId)
                .Index(t => t.IsDeleted);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Location_Id = c.Int(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.IsDeleted)
                .Index(t => t.Location_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "AvatarUrl", c => c.String());
            AddColumn("dbo.AspNetUsers", "FacebookUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sports", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Locations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Sports", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Sports", new[] { "User_Id" });
            DropIndex("dbo.Sports", new[] { "Location_Id" });
            DropIndex("dbo.Sports", new[] { "IsDeleted" });
            DropIndex("dbo.Locations", new[] { "IsDeleted" });
            DropIndex("dbo.Locations", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "IsDeleted" });
            DropColumn("dbo.AspNetUsers", "FacebookUrl");
            DropColumn("dbo.AspNetUsers", "AvatarUrl");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Sports");
            DropTable("dbo.Locations");
            DropTable("dbo.Cities");
        }
    }
}
