using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace HealthHarmony2.Models
{

    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        #region user name
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        [RegularExpression(@"[A-Za-z\s]{3,}", ErrorMessage = "Name can have alphabets & Numbers with min size of 3.")]
        public string Username { get; set; }
        #endregion

        #region Email

        [RegularExpression(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Email is not in Correct Formate")]
        [EmailAddress(ErrorMessage = "Email is not in Correct Formate")]
        public string Email { get; set; }
        #endregion

        #region Password
        [Required(ErrorMessage = "Password field can't be left empty.")]
        [RegularExpression(@"(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$_-])(?=\S+$).{8,16}", ErrorMessage = "Password Shoud have at least 1 Upper character,1 lower character ,simbold and 1 number ")]
        

        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must be between 6 and 100 characters", MinimumLength = 6)]
        public string Password { get; set; }

        #endregion
    
        public ICollection<UserRole> UserRoles { get; set; }

    }
}