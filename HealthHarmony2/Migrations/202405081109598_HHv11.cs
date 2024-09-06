namespace HealthHarmony2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HHv11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 100));
        }

        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String());
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false));
        }
    }
}
