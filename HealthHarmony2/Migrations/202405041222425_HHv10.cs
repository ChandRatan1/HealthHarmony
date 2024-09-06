namespace HealthHarmony2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HHv10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercise", "ExerciseInstructions", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Exercise", "ExerciseInstructions");
        }
    }
}
