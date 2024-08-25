using Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test_next_coders.Models;
using test_next_coders.DTOs;
using Microsoft.EntityFrameworkCore;
using TaskStatus = test_next_coders.Models.TaskStatus;
using System.Runtime.ConstrainedExecution;

namespace test_next_coders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly NextCodersDbContext _context;

        public TaskController(NextCodersDbContext context)
        {
            _context = context;
        }

        // POST: api/task/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskDTO taskDTO)
        {
            if (taskDTO == null)
            {
                return BadRequest("A tarefa não pode estar vazia.");
            }

            var newTask = new TaskModel
            {
                Title = taskDTO.Title,
                Description = taskDTO.Description,
                Status = (Models.TaskStatus)taskDTO.taskStatus,
            };

            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();

            return Ok(newTask);
        }

        // GET: api/task/read
        [HttpGet("read")]
        public async Task<IActionResult> ReadByStatusAsync(int status)
        {
            if (status < 0 || status > 2)
            {
                return BadRequest("Status inválido. O status deve ser 0 (Pendente), 1 (Em andamento), ou 2 (Concluída).");
            }

            // Conversão de tipo / conversão explícita
            // Conversão de enum para int: EmAndamento = 1
            var taskStatus = (TaskStatus)status;

            try
            {
                var tasks = await _context.Tasks
                    .Where(t => t.Status == taskStatus)
                    .Select(t => new ReadTaskDTO
                    {
                        Title = t.Title,
                        Description = t.Description,
                        taskStatus = (TaskStatusDTO)t.Status,
                        CreatedAt = t.CreatedAt
                    })
                    .ToListAsync();

                // Usado quando a solicitação foi bem-sucedida, mas não há dados para retornar.
                // Se não houver tarefas a serem retornadas, a API retorna um status 204 No Content
                if (!tasks.Any())
                {
                    return NoContent();
                }

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor. {ex.Message}");
            }
        }

        // PUT: api/task/update
        [HttpPut("update")]
        public async Task<IActionResult> UpdateTaskByIdAsync(int id, [FromBody] TaskDTO taskDTO)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound("Task não encontrada.");
            }

            task.Title = taskDTO.Title;
            task.Description = taskDTO.Description;
            task.Status = (TaskStatus)taskDTO.taskStatus;

            // Define a completion date se o Status for Concluida = 2
            if (task.Status == TaskStatus.Concluida)
            {
                task.CompletionDate = DateTime.Now;
            }

            await _context.SaveChangesAsync();

            return Ok("Task atualizada com sucesso!");
        }

        // DELETE: api/task/delete
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteTaskByIdAsync(int id, TaskDTO taskDTO)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound("Task não encontrada.");
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}