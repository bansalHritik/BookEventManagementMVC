namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedEmailInvitesColumnFromEventTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "EmailInvites");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EmailInvites", c => c.String());
        }
    }
}
