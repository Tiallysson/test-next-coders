using System.ComponentModel.DataAnnotations;

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
    }
    public class ReadTaskDTO
    {
        [Required(ErrorMessage = "O campo titulo é obrigatório")]
        public required string Title { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public required string Description { get; set; }
        public TaskStatusDTO taskStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
