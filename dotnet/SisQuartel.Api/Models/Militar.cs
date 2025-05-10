namespace SisQuartel.Api.Models;

public class Militar
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Patente { get; set; }
    public string? Batalhao { get; set; }
    public DateTime? DataNascimento { get; set; }
}
