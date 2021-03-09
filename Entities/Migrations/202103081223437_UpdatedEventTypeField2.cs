namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEventTypeField2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Type", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Type", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
