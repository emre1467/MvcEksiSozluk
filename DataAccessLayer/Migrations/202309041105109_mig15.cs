namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig15 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "Status", c => c.Boolean(nullable: false));
        }
    }
}
