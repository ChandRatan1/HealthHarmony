namespace HealthHarmony2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HHv5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exercise", "ExerciseCategory_CategoryID", c => c.Int());
            CreateIndex("dbo.Exercise", "ExerciseCategory_CategoryID");
            AddForeignKey("dbo.Exercise", "ExerciseCategory_CategoryID", "dbo.Exercise Category", "CategoryID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Exercise", "ExerciseCategory_CategoryID", "dbo.Exercise Category");
            DropIndex("dbo.Exercise", new[] { "ExerciseCategory_CategoryID" });
            DropColumn("dbo.Exercise", "ExerciseCategory_CategoryID");
        }
    }
}
