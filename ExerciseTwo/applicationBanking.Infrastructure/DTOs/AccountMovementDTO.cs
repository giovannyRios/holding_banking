using System.ComponentModel.DataAnnotations;

public class AccountMovementDTO
{
    public string? id { get; set; }

    [Required(ErrorMessage = "La cuenta es requerida para el movimiento")]
    public string? accountId { get; set; }

    [Required(ErrorMessage = "El tipo de movimiento es requerido")]
    public string? type { get; set; }

    [Required(ErrorMessage = "El monto es requerido")]
    [Range(1, double.MaxValue, ErrorMessage = "El monto debe ser mayor o igual a 1")]
    public double amount { get; set; }

    public string date { get; set; }
}