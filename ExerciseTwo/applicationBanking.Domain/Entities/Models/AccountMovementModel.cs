using System.ComponentModel.DataAnnotations;

public class AccountMovementModel
{
    public string? id { get; set; }

    public string? accountId { get; set; }

    public string? type { get; set; }

    public double amount { get; set; }

    public string? date { get; set; }
}