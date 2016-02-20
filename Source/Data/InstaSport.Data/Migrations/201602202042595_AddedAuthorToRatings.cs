namespace InstaSport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuthorToRatings : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Ratings", name: "User_Id", newName: "AuthorId");
            RenameIndex(table: "dbo.Ratings", name: "IX_User_Id", newName: "IX_AuthorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Ratings", name: "IX_AuthorId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Ratings", name: "AuthorId", newName: "User_Id");
        }
    }
}
