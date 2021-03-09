namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuthorIdToEvent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "AuthorId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "AuthorId");
        }
    }
}
