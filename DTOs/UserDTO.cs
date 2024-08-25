using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test_next_coders.DTOs
{
    public class UserDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

    }

    public class UserAtualizationDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
    }
}
