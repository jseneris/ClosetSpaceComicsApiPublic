namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class publisherImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publishers", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Publishers", "ImageName");
        }
    }
}
