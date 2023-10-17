namespace WarehouseInventory.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryadddescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "Description", c => c.String(nullable: false, maxLength: 4000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "Description");
        }
    }
}
