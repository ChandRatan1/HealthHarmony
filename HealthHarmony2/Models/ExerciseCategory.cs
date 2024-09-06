using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthHarmony2.Models
{
    [Table("Exercise Category")]
    public class ExerciseCategory
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [MaxLength(1000)]
        public string CategoryDescription { get; set; }
        public string CategoryImage { get; set; }
       // public ICollection<ExerciseCategoryAssignment> ExerciseCategoryAssignments { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}