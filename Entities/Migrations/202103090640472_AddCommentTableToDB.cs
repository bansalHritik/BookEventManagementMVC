namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentTableToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        Content = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
  
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropTable("dbo.Comments");
        }
    }
}
