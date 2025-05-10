using Microsoft.EntityFrameworkCore;
using SisQuartel.Api.Models;

namespace SisQuartel.Api.Repositories;

public class SisQuartelContext : DbContext
{
    //Tabela
    public DbSet<Militar> Militares { get; set; }

    public SisQuartelContext(DbContextOptions<SisQuartelContext> options)
          : base(options)
      {
      }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Militar>(entity =>
        {
            entity.HasKey(militar => militar.Id);

            entity.Property(militar => militar.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd();

            entity.Property(militar => militar.Nome)
                  .HasColumnName("nome")
                  .HasMaxLength(255)
                  .IsRequired();

            entity.Property(militar => militar.Patente)
                  .HasColumnName("patente")
                  .HasMaxLength(64);

            entity.Property(militar => militar.Batalhao)
                  .HasColumnName("batalhao")
                  .HasMaxLength(255);

            entity.Property(militar => militar.DataNascimento)
                  .HasColumnName("data_nascimento");
        });
    }
}
