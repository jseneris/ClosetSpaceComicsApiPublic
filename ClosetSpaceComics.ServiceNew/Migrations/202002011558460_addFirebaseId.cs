namespace ClosetSpaceComics.ServiceNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFirebaseId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirebaseId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "FirebaseId");
        }
    }
}
