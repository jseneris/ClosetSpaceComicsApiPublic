namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class issuecreateddate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "CreatedDated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "CreatedDated");
        }
    }
}
