namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class syncup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Boxes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.PurchaseItems",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LocalTitleId = c.Int(nullable: false),
                        LocalIssueId = c.Int(nullable: false),
                        Condition = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Notes = c.String(),
                        GradingService = c.Int(),
                        GradedCondition = c.Int(),
                        PaperQuality = c.Int(),
                        CertificateNumber = c.String(),
                        PurchaseId = c.Int(nullable: false),
                        BoxId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Boxes", t => t.BoxId, cascadeDelete: true)
                .ForeignKey("dbo.Purchases", t => t.PurchaseId, cascadeDelete: true)
                .Index(t => t.PurchaseId)
                .Index(t => t.BoxId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        PurchaseItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PurchaseItems", t => t.PurchaseItemId, cascadeDelete: true)
                .Index(t => t.PurchaseItemId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Description = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        SeoFriendlyName = c.String(),
                        IssueNumberOrdinal = c.Int(nullable: false),
                        Description = c.String(),
                        CoverPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReleaseDate = c.DateTime(),
                        ImageUrl = c.String(),
                        TitleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: true)
                .Index(t => t.TitleId);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        SeoFriendlyName = c.String(),
                        YearStart = c.Int(nullable: false),
                        YearEnd = c.Int(),
                        IssueBegin = c.String(),
                        IssueEnd = c.String(),
                        LastUpdate = c.DateTime(),
                        LoneStarId = c.String(),
                        LocalTitleId = c.Int(),
                        PublisherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishers", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        SeoFriendlyName = c.String(),
                        LocalId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocalTitles",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Boxes", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.PurchaseItems", "PurchaseId", "dbo.Purchases");
            DropForeignKey("dbo.Purchases", "UserId", "dbo.Users");
            DropForeignKey("dbo.Locations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Photos", "PurchaseItemId", "dbo.PurchaseItems");
            DropForeignKey("dbo.PurchaseItems", "BoxId", "dbo.Boxes");
            DropIndex("dbo.Titles", new[] { "PublisherId" });
            DropIndex("dbo.Issues", new[] { "TitleId" });
            DropIndex("dbo.Locations", new[] { "UserId" });
            DropIndex("dbo.Purchases", new[] { "UserId" });
            DropIndex("dbo.Photos", new[] { "PurchaseItemId" });
            DropIndex("dbo.PurchaseItems", new[] { "BoxId" });
            DropIndex("dbo.PurchaseItems", new[] { "PurchaseId" });
            DropIndex("dbo.Boxes", new[] { "LocationId" });
            DropTable("dbo.LocalTitles");
            DropTable("dbo.Publishers");
            DropTable("dbo.Titles");
            DropTable("dbo.Issues");
            DropTable("dbo.Locations");
            DropTable("dbo.Users");
            DropTable("dbo.Purchases");
            DropTable("dbo.Photos");
            DropTable("dbo.PurchaseItems");
            DropTable("dbo.Boxes");
        }
    }
}
