namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class localissuenumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseItems", "IssueNumber", c => c.String());
            AddColumn("dbo.PurchaseItems", "IssueNumberOrdinal", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseItems", "IssueNumberOrdinal");
            DropColumn("dbo.PurchaseItems", "IssueNumber");
        }
    }
}
