using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_next_coders.Models
{
    [Table("users")]
    public class UserModel
    {
        [Key]
        [Column("Id")]
        public long Id { get; set; }

        [Column("Name")]
        [MaxLength(32)]
        public required string Name { get; set; }

        [Column("Email")]
        [MaxLength(255)]
        public required string Email { get; set; }

        [Column("Password")]
        [MaxLength(255)]
        public required string Password { get; set; }

        public ICollection<TaskModel> Tasks { get; set; }
    }
}
