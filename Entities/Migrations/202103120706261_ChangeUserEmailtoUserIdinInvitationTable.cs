namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserEmailtoUserIdinInvitationTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invitations", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.Invitations", "UserEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invitations", "UserEmail", c => c.String(nullable: false));
            DropColumn("dbo.Invitations", "UserId");
        }
    }
}
