namespace HealthHarmony2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HHv6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercise", "ExerciseCategoryId", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Exercise", "ExerciseCategoryId");
        }
    }
}
