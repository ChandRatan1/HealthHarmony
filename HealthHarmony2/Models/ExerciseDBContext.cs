using HealthHarmony2.Migrations;
using System.Data.Entity;

namespace HealthHarmony2.Models
{
    public class ExerciseDBContext : DbContext
    {
        public ExerciseDBContext() : base("ConStr")
        {
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ExerciseDBContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ExerciseDBContext, Configuration>());
        }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<DietPlan> DietPlans { get; set; }
        public DbSet<User> Users { get; set; }
       // public DbSet<UserDietPlans> UserDietPlans { get; set; }
        public DbSet<ExerciseCategory> ExerciseCategories { get; set; }
      //  public DbSet<ExerciseCategoryAssignment> exerciseCategoryAssignments { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

    }
}