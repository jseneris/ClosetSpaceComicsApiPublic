namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseIssueToPurchase : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PurchaseItems", "IssueId");
            AddForeignKey("dbo.PurchaseItems", "IssueId", "dbo.Issues", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseItems", "IssueId", "dbo.Issues");
            DropIndex("dbo.PurchaseItems", new[] { "IssueId" });
        }
    }
}
