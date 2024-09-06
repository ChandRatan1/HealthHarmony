namespace HealthHarmony2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HHv15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diet Plan", "DietDescription", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Diet Plan", "DietDescription", c => c.String(maxLength: 1000));
        }
    }
}
