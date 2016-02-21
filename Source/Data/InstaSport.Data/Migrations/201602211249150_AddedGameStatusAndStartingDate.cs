namespace InstaSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGameStatusAndStartingDate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationId = c.Int(nullable: false),
                        SportId = c.Int(nullable: false),
                        StartingDateTime = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        MinPlayers = c.Int(),
                        MaxPlayers = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .Index(t => t.LocationId)
                .Index(t => t.SportId)
                .Index(t => t.IsDeleted);
            
            AddColumn("dbo.AspNetUsers", "Game_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Game_Id");
            AddForeignKey("dbo.AspNetUsers", "Game_Id", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "SportId", "dbo.Sports");
            DropForeignKey("dbo.AspNetUsers", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.Games", "LocationId", "dbo.Locations");
            DropIndex("dbo.AspNetUsers", new[] { "Game_Id" });
            DropIndex("dbo.Games", new[] { "IsDeleted" });
            DropIndex("dbo.Games", new[] { "SportId" });
            DropIndex("dbo.Games", new[] { "LocationId" });
            DropColumn("dbo.AspNetUsers", "Game_Id");
            DropTable("dbo.Games");
        }
    }
}
