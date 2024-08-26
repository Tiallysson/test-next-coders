using System.ComponentModel.DataAnnotations;
using test_next_coders.Models;

namespace test_next_coders.DTOs
{
    public enum TaskStatusDTO
    {
        Pendente = 0,
        EmAndamento = 1,
        Concluida = 2
    }
    public class TaskDTO
    {
        [Required(ErrorMessage = "O campo titulo é obrigatório")]
        public required string Title { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public required string Description { get; set; }
        public TaskStatusDTO taskStatus { get; set; }
        public required long UserId { get; set; }
    }
    public class ReadTaskDTO
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public TaskStatusDTO taskStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
