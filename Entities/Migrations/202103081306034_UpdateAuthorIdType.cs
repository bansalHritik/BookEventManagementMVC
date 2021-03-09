namespace Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAuthorIdType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "AuthorId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "AuthorId", c => c.Int(nullable: false));
        }
    }
}
