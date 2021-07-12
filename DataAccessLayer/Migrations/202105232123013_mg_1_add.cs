namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg_1_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterTittle", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterTittle");
        }
    }
}
