namespace HealthHarmony2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HHv7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Exercise", "ExerciseCategory_CategoryID", "dbo.Exercise Category");
            DropIndex("dbo.Exercise", new[] { "ExerciseCategory_CategoryID" });
            CreateTable(
                "dbo.ExerciseExerciseCategories",
                c => new
                {
                    Exercise_ExerciseID = c.Int(nullable: false),
                    ExerciseCategory_CategoryID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Exercise_ExerciseID, t.ExerciseCategory_CategoryID })
                .ForeignKey("dbo.Exercise", t => t.Exercise_ExerciseID, cascadeDelete: true)
                .ForeignKey("dbo.Exercise Category", t => t.ExerciseCategory_CategoryID, cascadeDelete: true)
                .Index(t => t.Exercise_ExerciseID)
                .Index(t => t.ExerciseCategory_CategoryID);

            DropColumn("dbo.Exercise", "ExerciseCategory_CategoryID");
        }

        public override void Down()
        {
            AddColumn("dbo.Exercise", "ExerciseCategory_CategoryID", c => c.Int());
            DropForeignKey("dbo.ExerciseExerciseCategories", "ExerciseCategory_CategoryID", "dbo.Exercise Category");
            DropForeignKey("dbo.ExerciseExerciseCategories", "Exercise_ExerciseID", "dbo.Exercise");
            DropIndex("dbo.ExerciseExerciseCategories", new[] { "ExerciseCategory_CategoryID" });
            DropIndex("dbo.ExerciseExerciseCategories", new[] { "Exercise_ExerciseID" });
            DropTable("dbo.ExerciseExerciseCategories");
            CreateIndex("dbo.Exercise", "ExerciseCategory_CategoryID");
            AddForeignKey("dbo.Exercise", "ExerciseCategory_CategoryID", "dbo.Exercise Category", "CategoryID");
        }
    }
}
