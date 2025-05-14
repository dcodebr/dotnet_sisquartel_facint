using System.ComponentModel.DataAnnotations;

namespace SisQuartel.Api.Models;

public class Patente
{
    public int Id { get; set; }

    public string? Graduacao { get; set; }

    public virtual ICollection<Militar>? Militares { get; set; }
}
