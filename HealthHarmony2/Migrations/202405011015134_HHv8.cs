namespace HealthHarmony2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HHv8 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExerciseExerciseCategories", "Exercise_ExerciseID", "dbo.Exercise");
            DropForeignKey("dbo.ExerciseExerciseCategories", "ExerciseCategory_CategoryID", "dbo.Exercise Category");
            DropIndex("dbo.ExerciseExerciseCategories", new[] { "Exercise_ExerciseID" });
            DropIndex("dbo.ExerciseExerciseCategories", new[] { "ExerciseCategory_CategoryID" });
            AddColumn("dbo.Exercise", "ExerciseCategory_CategoryID", c => c.Int());
            CreateIndex("dbo.Exercise", "ExerciseCategory_CategoryID");
            AddForeignKey("dbo.Exercise", "ExerciseCategory_CategoryID", "dbo.Exercise Category", "CategoryID");
            DropTable("dbo.ExerciseExerciseCategories");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.ExerciseExerciseCategories",
                c => new
                {
                    Exercise_ExerciseID = c.Int(nullable: false),
                    ExerciseCategory_CategoryID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Exercise_ExerciseID, t.ExerciseCategory_CategoryID });

            DropForeignKey("dbo.Exercise", "ExerciseCategory_CategoryID", "dbo.Exercise Category");
            DropIndex("dbo.Exercise", new[] { "ExerciseCategory_CategoryID" });
            DropColumn("dbo.Exercise", "ExerciseCategory_CategoryID");
            CreateIndex("dbo.ExerciseExerciseCategories", "ExerciseCategory_CategoryID");
            CreateIndex("dbo.ExerciseExerciseCategories", "Exercise_ExerciseID");
            AddForeignKey("dbo.ExerciseExerciseCategories", "ExerciseCategory_CategoryID", "dbo.Exercise Category", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.ExerciseExerciseCategories", "Exercise_ExerciseID", "dbo.Exercise", "ExerciseID", cascadeDelete: true);
        }
    }
}
