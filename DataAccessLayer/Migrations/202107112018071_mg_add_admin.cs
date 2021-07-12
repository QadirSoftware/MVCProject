namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_add_admin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminUserName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminPassword");
            DropColumn("dbo.Admins", "AdminUserName");
        }
    }
}
