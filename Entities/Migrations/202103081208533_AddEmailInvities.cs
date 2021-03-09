namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailInvities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EmailInvites", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EmailInvites");
        }
    }
}
