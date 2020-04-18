namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TurningIdentityOff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers");
            DropPrimaryKey("dbo.Issues");
            DropPrimaryKey("dbo.Titles");
            DropPrimaryKey("dbo.Publishers");
            DropPrimaryKey("dbo.LocalTitles");
            AlterColumn("dbo.Issues", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Titles", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Publishers", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.LocalTitles", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Issues", "Id");
            AddPrimaryKey("dbo.Titles", "Id");
            AddPrimaryKey("dbo.Publishers", "Id");
            AddPrimaryKey("dbo.LocalTitles", "Id");
            AddForeignKey("dbo.Issues", "TitleId", "dbo.Titles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Issues", "TitleId", "dbo.Titles");
            DropPrimaryKey("dbo.LocalTitles");
            DropPrimaryKey("dbo.Publishers");
            DropPrimaryKey("dbo.Titles");
            DropPrimaryKey("dbo.Issues");
            AlterColumn("dbo.LocalTitles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Publishers", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Titles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Issues", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.LocalTitles", "Id");
            AddPrimaryKey("dbo.Publishers", "Id");
            AddPrimaryKey("dbo.Titles", "Id");
            AddPrimaryKey("dbo.Issues", "Id");
            AddForeignKey("dbo.Titles", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Issues", "TitleId", "dbo.Titles", "Id", cascadeDelete: true);
        }
    }
}
