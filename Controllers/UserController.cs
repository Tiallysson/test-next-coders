using Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_next_coders.Models;
using test_next_coders.DTOs;

namespace test_next_coders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly NextCodersDbContext _context;

        public UserController(NextCodersDbContext context)
        {
            _context = context;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> UserRegisterAsync([FromBody] UserDTO userDTO)
        {
            if (userDTO == null)
            {
                return BadRequest("Todos os campos devem ser preenchidos.");
            }

            var userExists = await _context.Users
                .Where(u => u.Email == userDTO.Email)
                .FirstOrDefaultAsync();

            if (userExists != null)
            {
                return BadRequest("Email já cadastrado.");
            }

            var user = new UserModel
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        // PUT: api/user
        [HttpPut]
        public async Task<IActionResult> DataUpdateUserAsync(int id, [FromBody] UserAtualizationDTO userAtualizationDTO)
        {
            if (userAtualizationDTO == null)
            {
                return BadRequest("Todos os campos devem ser preenchidos.");
            }

            var userExists = await _context.Users.FindAsync(id);
            if (userExists == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            userExists.Name = userAtualizationDTO.Name;
            userExists.Email = userAtualizationDTO.Email;

            try
            {
                _context.Users.Update(userExists);
                await _context.SaveChangesAsync();

                return Ok(userExists);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Ocorreu um erro inesperado: {ex.Message}");
            }
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id, UserDTO userDTO)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
