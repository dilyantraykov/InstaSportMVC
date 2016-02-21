namespace InstaSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeGameToUserManyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Game_Id", "dbo.Games");
            DropIndex("dbo.AspNetUsers", new[] { "Game_Id" });
            CreateTable(
                "dbo.UserGames",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Game_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Game_Id);
            
            DropColumn("dbo.AspNetUsers", "Game_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Game_Id", c => c.Int());
            DropForeignKey("dbo.UserGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.UserGames", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserGames", new[] { "Game_Id" });
            DropIndex("dbo.UserGames", new[] { "User_Id" });
            DropTable("dbo.UserGames");
            CreateIndex("dbo.AspNetUsers", "Game_Id");
            AddForeignKey("dbo.AspNetUsers", "Game_Id", "dbo.Games", "Id");
        }
    }
}
