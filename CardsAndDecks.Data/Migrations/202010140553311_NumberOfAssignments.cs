namespace CardsAndDecks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberOfAssignments : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "NumberOfAssignments", c => c.Int(nullable: false));
            AddColumn("dbo.Deck", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Deck", "ApplicationUser_Id");
            AddForeignKey("dbo.Deck", "ApplicationUser_Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deck", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Deck", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Deck", "ApplicationUser_Id");
            DropColumn("dbo.Assignment", "NumberOfAssignments");
        }
    }
}
