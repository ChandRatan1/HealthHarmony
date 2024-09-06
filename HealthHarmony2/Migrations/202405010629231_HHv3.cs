namespace HealthHarmony2.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class HHv3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diet Plan",
                c => new
                {
                    DietPlanID = c.Int(nullable: false, identity: true),
                    DietName = c.String(nullable: false, maxLength: 100),
                    DietDescription = c.String(maxLength: 1000),
                    Calories = c.String(),
                })
                .PrimaryKey(t => t.DietPlanID);

            CreateTable(
                "dbo.User Diet Plans",
                c => new
                {
                    DietPlanID = c.Int(nullable: false),
                    UserID = c.Int(nullable: false),
                    DietName = c.String(),
                    StartDate = c.DateTime(nullable: false),
                    EndDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.DietPlanID)
                .ForeignKey("dbo.Diet Plan", t => t.DietPlanID)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.DietPlanID)
                .Index(t => t.UserID);

            CreateTable(
                "dbo.User",
                c => new
                {
                    UserID = c.Int(nullable: false, identity: true),
                    Username = c.String(nullable: false),
                    Email = c.String(),
                    Password = c.String(),
                })
                .PrimaryKey(t => t.UserID);

            CreateTable(
                "dbo.Exercise Category",
                c => new
                {
                    CategoryID = c.Int(nullable: false, identity: true),
                    CategoryName = c.String(nullable: false),
                    CategoryDescription = c.String(maxLength: 1000),
                })
                .PrimaryKey(t => t.CategoryID);

            CreateTable(
                "dbo.Exercise Category Assignment",
                c => new
                {
                    ExerciseID = c.Int(nullable: false),
                    CategoryID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ExerciseID)
                .ForeignKey("dbo.Exercise", t => t.ExerciseID)
                .ForeignKey("dbo.Exercise Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.ExerciseID)
                .Index(t => t.CategoryID);

            CreateTable(
                "dbo.Exercise",
                c => new
                {
                    ExerciseID = c.Int(nullable: false, identity: true),
                    ExerciseName = c.String(nullable: false, maxLength: 1000),
                    ExerciseDescription = c.String(maxLength: 1000),
                    ExerciseBodyPart = c.String(),
                })
                .PrimaryKey(t => t.ExerciseID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Exercise Category Assignment", "CategoryID", "dbo.Exercise Category");
            DropForeignKey("dbo.Exercise Category Assignment", "ExerciseID", "dbo.Exercise");
            DropForeignKey("dbo.User Diet Plans", "UserID", "dbo.User");
            DropForeignKey("dbo.User Diet Plans", "DietPlanID", "dbo.Diet Plan");
            DropIndex("dbo.Exercise Category Assignment", new[] { "CategoryID" });
            DropIndex("dbo.Exercise Category Assignment", new[] { "ExerciseID" });
            DropIndex("dbo.User Diet Plans", new[] { "UserID" });
            DropIndex("dbo.User Diet Plans", new[] { "DietPlanID" });
            DropTable("dbo.Exercise");
            DropTable("dbo.Exercise Category Assignment");
            DropTable("dbo.Exercise Category");
            DropTable("dbo.User");
            DropTable("dbo.User Diet Plans");
            DropTable("dbo.Diet Plan");
        }
    }
}
