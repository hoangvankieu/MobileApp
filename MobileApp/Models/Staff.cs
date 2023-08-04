using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MobileApp.Models
{
    [Table("staff")]
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("staff_id")]
        public int StaffId { get; set; }


        [Column("username")]
        [Required]
        [StringLength(100)]
        public string Username { get; set; } = "";


        [Column("hash_password")]
        [Required]
        public string HashPassword { get; set; } = "";


        [Column("role")]
        [StringLength(20)]
        public string Role { get; set; } = "";
    }
}
