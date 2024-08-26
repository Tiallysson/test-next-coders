using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test_next_coders.Models
{
    public enum TaskStatus
    {
        Pendente = 0,
        EmAndamento = 1,
        Concluida = 2
    }
    public class TaskModel
    {
        [Key]
        public long Id { get; set; }

        [Column("Title")]
        public required string Title { get; set; }

        [Column("Description")]
        public required string Description { get; set; }

        public required long UserId { get; set; }

        public TaskStatus Status { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("CompletionDate")]
        public DateTime? CompletionDate { get; set; }

        [Column("UserId")]
        public UserModel User { get; set; }
    }
}
