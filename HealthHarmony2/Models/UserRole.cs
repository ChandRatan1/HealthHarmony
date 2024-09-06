using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;

namespace HealthHarmony2.Models
{
    [TableName("UserRole")]
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public string Role { get; set; }
    }
}