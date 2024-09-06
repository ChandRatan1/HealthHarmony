namespace HealthHarmony2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HHv4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diet Plan", "DietPlanImage", c => c.String());
            AddColumn("dbo.Exercise Category", "CategoryImage", c => c.String());
            AddColumn("dbo.Exercise", "ExerciseImage", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Exercise", "ExerciseImage");
            DropColumn("dbo.Exercise Category", "CategoryImage");
            DropColumn("dbo.Diet Plan", "DietPlanImage");
        }
    }
}
