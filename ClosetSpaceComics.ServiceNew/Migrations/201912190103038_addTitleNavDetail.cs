namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTitleNavDetail : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PurchaseItems", "TitleId");
            AddForeignKey("dbo.PurchaseItems", "TitleId", "dbo.Titles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseItems", "TitleId", "dbo.Titles");
            DropIndex("dbo.PurchaseItems", new[] { "TitleId" });
        }
    }
}
