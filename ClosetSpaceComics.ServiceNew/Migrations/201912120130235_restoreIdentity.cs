namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restoreIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseItems", "BoxId", "dbo.Boxes");
            DropForeignKey("dbo.Photos", "PurchaseItemId", "dbo.PurchaseItems");
            DropForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Boxes", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Issues", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers");
            DropPrimaryKey("dbo.Boxes");
            DropPrimaryKey("dbo.PurchaseItems");
            DropPrimaryKey("dbo.Photos");
            DropPrimaryKey("dbo.Purchases");
            DropPrimaryKey("dbo.Locations");
            DropPrimaryKey("dbo.Issues");
            DropPrimaryKey("dbo.Titles");
            DropPrimaryKey("dbo.Publishers");
            DropPrimaryKey("dbo.LocalTitles");
            AlterColumn("dbo.Boxes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PurchaseItems", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Photos", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Purchases", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Locations", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Issues", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Titles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Publishers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.LocalTitles", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Boxes", "Id");
            AddPrimaryKey("dbo.PurchaseItems", "Id");
            AddPrimaryKey("dbo.Photos", "Id");
            AddPrimaryKey("dbo.Purchases", "Id");
            AddPrimaryKey("dbo.Locations", "Id");
            AddPrimaryKey("dbo.Issues", "Id");
            AddPrimaryKey("dbo.Titles", "Id");
            AddPrimaryKey("dbo.Publishers", "Id");
            AddPrimaryKey("dbo.LocalTitles", "Id");
            AddForeignKey("dbo.PurchaseItems", "BoxId", "dbo.Boxes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Photos", "PurchaseItemId", "dbo.PurchaseItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Boxes", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Issues", "TitleId", "dbo.Titles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Issues", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Boxes", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Photos", "PurchaseItemId", "dbo.PurchaseItems");
            DropForeignKey("dbo.PurchaseItems", "BoxId", "dbo.Boxes");
            DropPrimaryKey("dbo.LocalTitles");
            DropPrimaryKey("dbo.Publishers");
            DropPrimaryKey("dbo.Titles");
            DropPrimaryKey("dbo.Issues");
            DropPrimaryKey("dbo.Locations");
            DropPrimaryKey("dbo.Purchases");
            DropPrimaryKey("dbo.Photos");
            DropPrimaryKey("dbo.PurchaseItems");
            DropPrimaryKey("dbo.Boxes");
            AlterColumn("dbo.LocalTitles", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Publishers", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Titles", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Issues", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Locations", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Purchases", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Photos", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseItems", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Boxes", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.LocalTitles", "Id");
            AddPrimaryKey("dbo.Publishers", "Id");
            AddPrimaryKey("dbo.Titles", "Id");
            AddPrimaryKey("dbo.Issues", "Id");
            AddPrimaryKey("dbo.Locations", "Id");
            AddPrimaryKey("dbo.Purchases", "Id");
            AddPrimaryKey("dbo.Photos", "Id");
            AddPrimaryKey("dbo.PurchaseItems", "Id");
            AddPrimaryKey("dbo.Boxes", "Id");
            AddForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Issues", "TitleId", "dbo.Titles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Boxes", "LocationId", "dbo.Locations", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Photos", "PurchaseItemId", "dbo.PurchaseItems", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PurchaseItems", "BoxId", "dbo.Boxes", "Id", cascadeDelete: true);
        }
    }
}
