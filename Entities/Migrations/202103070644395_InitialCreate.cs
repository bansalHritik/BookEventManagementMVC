namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(nullable: false),
                        EventType = c.Int(nullable: false),
                        Duration = c.Byte(),
                        Description = c.String(maxLength: 50),
                        OtherDetails = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
