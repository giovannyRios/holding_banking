using System.ComponentModel.DataAnnotations;

public class Account
{
    [Key]
    public string? id { get; set; }

    public string? clientId { get; set; }

    public string? type { get; set; }

    public double balance { get; set; }
}