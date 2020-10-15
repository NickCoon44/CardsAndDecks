namespace CardsAndDecks.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAssignmentsToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Assignment", "ApplicationUserId");
            AddForeignKey("dbo.Assignment", "ApplicationUserId", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignment", "ApplicationUserId", "dbo.ApplicationUser");
            DropIndex("dbo.Assignment", new[] { "ApplicationUserId" });
            DropColumn("dbo.Assignment", "ApplicationUserId");
        }
    }
}
