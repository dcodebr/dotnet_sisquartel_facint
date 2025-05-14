namespace SisQuartel.Api.Models;

public class Batalhao
{
    public int Id { get; set; }
    public string? Identificacao { get; set; }

    public virtual ICollection<Militar>? Militares { get; set; }
}
