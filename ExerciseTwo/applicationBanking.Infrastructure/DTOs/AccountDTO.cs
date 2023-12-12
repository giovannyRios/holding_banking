using System.ComponentModel.DataAnnotations;
public class AccountDTO
{
    public string? id { get; set; }

    [Required(ErrorMessage = "El Cliente es requerido para la cuenta")]
    public string? clientId { get; set; }

    [Required(ErrorMessage = "El tipo de cuenta es requerido")]
    public string? type { get; set; }

    [Required(ErrorMessage = "El balance es requerido")]
    [Range(0, double.MaxValue, ErrorMessage = "El balance debe ser mayor o igual a 0")]
    public double balance { get; set; }
}