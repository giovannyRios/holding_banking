using System.ComponentModel.DataAnnotations;
public class ClientDTO
{
    public string? id { get; set; }
    
    [Required(ErrorMessage = "El nombre es requerido")]  
    public string? name { get; set; }

    [Required(ErrorMessage = "La identificacion es requerida")]
    public string? identify { get; set; }
}