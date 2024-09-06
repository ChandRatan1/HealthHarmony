using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace HealthHarmony2.Models
{
    [Table("Exercise")]
    public class Exercise
    {
        [Key]
        public int ExerciseID { get; set; }
        [Required]
        [MaxLength(1000)]
        public string ExerciseName { get; set; }
        [MaxLength(1000)]
        public string ExerciseDescription { get; set; }
        public string ExerciseBodyPart { get; set; }
        public string ExerciseImage { get; set; }
        public string ExerciseInstructions { get; set; }
        public int? ExerciseCategoryId { get; set; }  // This will hold the foreign key value

        // Navigation property
        [ForeignKey("ExerciseCategoryId")]
        public ExerciseCategory ExerciseCategory { get; set; }
       // public ICollection<ExerciseCategoryAssignment> ExerciseCategoryAssignments { get; set; }

        [NotMapped]
        public List<SelectListItem> Categories { get; set; }


    }
}