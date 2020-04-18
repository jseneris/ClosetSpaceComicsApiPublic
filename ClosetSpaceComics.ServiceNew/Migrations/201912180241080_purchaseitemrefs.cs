namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchaseitemrefs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseItems", "BoxId", "dbo.Boxes");
            DropForeignKey("dbo.Boxes", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Photos", "PurchaseItemId", "dbo.PurchaseItems");
            DropForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropForeignKey("dbo.Locations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Issues", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers");
            AlterColumn("dbo.PurchaseItems", "LocalTitleId", c => c.Int());
            AlterColumn("dbo.PurchaseItems", "LocalIssueId", c => c.Int());
            AddForeignKey("dbo.PurchaseItems", "BoxId", "dbo.Boxes", "Id");
            AddForeignKey("dbo.Boxes", "LocationId", "dbo.Locations", "Id");
            AddForeignKey("dbo.Photos", "PurchaseItemId", "dbo.PurchaseItems", "Id");
            AddForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases", "Id");
            AddForeignKey("dbo.Purchases", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Locations", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Issues", "TitleId", "dbo.Titles", "Id");
            AddForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Issues", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Locations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Photos", "PurchaseItemId", "dbo.PurchaseItems");
            DropForeignKey("dbo.Boxes", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.PurchaseItems", "BoxId", "dbo.Boxes");
            AlterColumn("dbo.PurchaseItems", "LocalIssueId", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseItems", "LocalTitleId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Issues", "TitleId", "dbo.Titles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locations", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Purchases", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Photos", "PurchaseItemId", "dbo.PurchaseItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Boxes", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseItems", "BoxId", "dbo.Boxes", "Id", cascadeDelete: true);
        }
    }
}
