namespace HealthHarmony2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HHv14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User Diet Plans", "DietPlanID", "dbo.Diet Plan");
            DropForeignKey("dbo.User Diet Plans", "UserID", "dbo.User");
            DropForeignKey("dbo.Exercise Category Assignment", "ExerciseID", "dbo.Exercise");
            DropForeignKey("dbo.Exercise Category Assignment", "CategoryID", "dbo.Exercise Category");
            DropIndex("dbo.User Diet Plans", new[] { "DietPlanID" });
            DropIndex("dbo.User Diet Plans", new[] { "UserID" });
            DropIndex("dbo.Exercise Category Assignment", new[] { "ExerciseID" });
            DropIndex("dbo.Exercise Category Assignment", new[] { "CategoryID" });
            DropTable("dbo.User Diet Plans");
            DropTable("dbo.Exercise Category Assignment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Exercise Category Assignment",
                c => new
                    {
                        ExerciseID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExerciseID);
            
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
                .PrimaryKey(t => t.DietPlanID);
            
            CreateIndex("dbo.Exercise Category Assignment", "CategoryID");
            CreateIndex("dbo.Exercise Category Assignment", "ExerciseID");
            CreateIndex("dbo.User Diet Plans", "UserID");
            CreateIndex("dbo.User Diet Plans", "DietPlanID");
            AddForeignKey("dbo.Exercise Category Assignment", "CategoryID", "dbo.Exercise Category", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Exercise Category Assignment", "ExerciseID", "dbo.Exercise", "ExerciseID");
            AddForeignKey("dbo.User Diet Plans", "UserID", "dbo.User", "UserID", cascadeDelete: true);
            AddForeignKey("dbo.User Diet Plans", "DietPlanID", "dbo.Diet Plan", "DietPlanID");
        }
    }
}
