using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthHarmony2.Models
{
    [Table("Diet Plan")]
    public class DietPlan
    {
        [Key]
        public int DietPlanID { get; set; }
        [Required]
        [MaxLength(100)]
        public string DietName { get; set; }
        //[MaxLength(1000, ErrorMessage = "Description is too large")]
        public string DietDescription { get; set; }

        public string Calories { get; set; }
        public string DietPlanImage { get; set; }
       // public ICollection<UserDietPlans> UserDietPlans { get; set; }
    }
}