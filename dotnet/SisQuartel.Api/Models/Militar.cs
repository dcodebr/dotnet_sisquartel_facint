namespace SisQuartel.Api.Models;

public class Militar
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    
    public int? PatenteId { get; set; }
    public int? BatalhaoId { get; set; }
    public DateTime? DataNascimento { get; set; }

    public virtual Patente? Patente { get; set; }
    public virtual Batalhao? Batalhao { get; set; }
}
