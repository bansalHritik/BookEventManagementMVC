namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEventTypeField1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Type", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Type", c => c.String(nullable: false));
        }
    }
}
