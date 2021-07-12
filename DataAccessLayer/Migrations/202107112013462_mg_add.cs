namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_add : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminUserName");
            DropColumn("dbo.Admins", "AdminPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
        }
    }
}
