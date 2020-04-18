namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publisherdisplayorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publishers", "DisplayOrder", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publishers", "DisplayOrder");
        }
    }
}
