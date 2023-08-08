using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geoportal.Models
{
    [Table("clients")]
    public class UsersModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("fullname")]
        public string FullName { get; set; }

        [Required]
        [Column("idpassportnumber")]
        public string IDNumber { get; set; }

        [Required]
        [Column("mobilenumber")]
        public string MobileNumber { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [NotMapped]
        [Column("confirmpassword")]
        public string ConfirmPassword { get; set; }

        [ForeignKey("role_id")]
        [Column("role_id")]// Updated foreign key column name
        public int RoleId { get; set; }

        // Navigation property for the Role entity
        public Role Role { get; set; }
    }
}
