namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_add_isreading : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "IsReading", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "IsReading");
        }
    }
}
