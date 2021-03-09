namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEventTypeField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "StartTime", c => c.String(nullable: false));
            AddColumn("dbo.Events", "Type", c => c.String(nullable: false));
            DropColumn("dbo.Events", "EventType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "EventType", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "Type");
            DropColumn("dbo.Events", "StartTime");
        }
    }
}
