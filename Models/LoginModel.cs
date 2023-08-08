using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geoportal.Models
{
    [Table("users")]
    public class LoginModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("role_id")]
        [Column("role_id")]
        public int RoleId { get; set; } 

     // Navigation property for the Role entity
        public Role Role { get; set; }
    }
}
