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
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletionDate { get; set; }
    }
}
