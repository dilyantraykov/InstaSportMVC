namespace InstaSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectlySeededGames : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sports", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Sports", new[] { "User_Id" });
            CreateTable(
                "dbo.UserSports",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Sport_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Sport_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sports", t => t.Sport_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Sport_Id);
            
            DropColumn("dbo.Sports", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sports", "User_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.UserSports", "Sport_Id", "dbo.Sports");
            DropForeignKey("dbo.UserSports", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserSports", new[] { "Sport_Id" });
            DropIndex("dbo.UserSports", new[] { "User_Id" });
            DropTable("dbo.UserSports");
            CreateIndex("dbo.Sports", "User_Id");
            AddForeignKey("dbo.Sports", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
