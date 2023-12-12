using System;
using System.ComponentModel.DataAnnotations;

public class Client
{
    [Key]
    public string? id { get; set; }

    public string? name { get; set; }

    public string? identify { get; set; }
}
