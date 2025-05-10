using Microsoft.EntityFrameworkCore;

namespace SisQuartel.Api.Repositories;

public class SisQuartelContextFactory
{
    public SisQuartelContext CreateDbContext(string[]? args = null)
    {
        var builder = new DbContextOptionsBuilder<SisQuartelContext>();
        var connectionString = "server=localhost;user=root;password=root;database=sisquartel;";

        builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        return new SisQuartelContext(builder.Options);
    }
}
