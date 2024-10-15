using System.ComponentModel;

namespace Core.Dtos
{
    public class LoginDto
    {
        [DefaultValue("vit1@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("Qwer-1234!")]
        public string Password { get; set; }
    }
}
