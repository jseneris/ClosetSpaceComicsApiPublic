namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtitleids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseItems", "TitleId", c => c.Int());
            AddColumn("dbo.PurchaseItems", "IssueId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseItems", "IssueId");
            DropColumn("dbo.PurchaseItems", "TitleId");
        }
    }
}
