using System.ComponentModel.DataAnnotations;

namespace Hotel.ViewModels
{
    public class LoginViewModel
    {
        [Required, MinLength(6, ErrorMessage = "Username must contain at least 6 characters")]
        public string Username { get; set; }

        [Required, DataType(DataType.Password), MinLength(6, ErrorMessage = "Password must contain at least 6 characters")]
        public string Password { get; set; }
    }
}
