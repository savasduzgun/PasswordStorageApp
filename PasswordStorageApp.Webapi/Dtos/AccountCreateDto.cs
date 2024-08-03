using System.ComponentModel.DataAnnotations;

namespace PasswordStorageApp.Webapi.Dtos
{
    public class AccountCreateDto
    {
        [Required, MinLength(6),MaxLength(40)]
        public string Username { get; set; }

        [Required, MinLength(6), MaxLength(40)]
        public string Password { get; set; }
    }
}
