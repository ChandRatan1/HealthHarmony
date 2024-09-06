namespace HealthHarmony2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HHv9 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Exercise", new[] { "ExerciseCategory_CategoryID" });
            DropColumn("dbo.Exercise", "ExerciseCategoryId");
            RenameColumn(table: "dbo.Exercise", name: "ExerciseCategory_CategoryID", newName: "ExerciseCategoryId");
            AlterColumn("dbo.Exercise", "ExerciseCategoryId", c => c.Int());
            CreateIndex("dbo.Exercise", "ExerciseCategoryId");
        }

        public override void Down()
        {
            DropIndex("dbo.Exercise", new[] { "ExerciseCategoryId" });
            AlterColumn("dbo.Exercise", "ExerciseCategoryId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Exercise", name: "ExerciseCategoryId", newName: "ExerciseCategory_CategoryID");
            AddColumn("dbo.Exercise", "ExerciseCategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exercise", "ExerciseCategory_CategoryID");
        }
    }
}
