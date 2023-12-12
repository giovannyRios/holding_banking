using System.ComponentModel.DataAnnotations;

namespace ApplicationBanking.Application.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        public string user { get; set; }

        [Required(ErrorMessage = "La contraseña es requerido")]
        public string pass { get; set; }
    }
}
