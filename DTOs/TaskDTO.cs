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
        public string Title { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Description { get; set; }
        public TaskStatusDTO taskStatus { get; set; }
    }
}
