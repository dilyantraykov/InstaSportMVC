namespace InstaSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SportsNowHaveCollectionOfUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sports", "Location_Id", "dbo.Locations");
            DropIndex("dbo.Sports", new[] { "Location_Id" });
            CreateTable(
                "dbo.SportLocations",
                c => new
                    {
                        Sport_Id = c.Int(nullable: false),
                        Location_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Sport_Id, t.Location_Id })
                .ForeignKey("dbo.Sports", t => t.Sport_Id, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .Index(t => t.Sport_Id)
                .Index(t => t.Location_Id);
            
            DropColumn("dbo.Sports", "Location_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sports", "Location_Id", c => c.Int());
            DropForeignKey("dbo.SportLocations", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.SportLocations", "Sport_Id", "dbo.Sports");
            DropIndex("dbo.SportLocations", new[] { "Location_Id" });
            DropIndex("dbo.SportLocations", new[] { "Sport_Id" });
            DropTable("dbo.SportLocations");
            CreateIndex("dbo.Sports", "Location_Id");
            AddForeignKey("dbo.Sports", "Location_Id", "dbo.Locations", "Id");
        }
    }
}
