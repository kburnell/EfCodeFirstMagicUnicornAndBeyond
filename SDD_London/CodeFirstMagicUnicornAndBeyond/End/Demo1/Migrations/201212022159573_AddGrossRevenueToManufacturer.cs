namespace Demo1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGrossRevenueToManufacturer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Manufacturer", "GrossRevenue", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Manufacturer", "GrossRevenue");
        }
    }
}
