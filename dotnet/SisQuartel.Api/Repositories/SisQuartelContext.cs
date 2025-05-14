using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SisQuartel.Api.Models;

namespace SisQuartel.Api.Repositories;

public class SisQuartelContext : DbContext
{
    //Tabela
    public DbSet<Militar> Militares { get; set; }
    public DbSet<Patente> Patentes { get; set; }
    public DbSet<Batalhao> Batalhoes { get; set; }

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
            entity.ToTable("militar");

            entity.HasKey(militar => militar.Id);

            entity.Property(militar => militar.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd();

            entity.Property(militar => militar.Nome)
                  .HasColumnName("nome")
                  .HasMaxLength(255)
                  .IsRequired();

            entity.Property(militar => militar.PatenteId)
                  .HasColumnName("id_patente");

            entity.HasOne(militar => militar.Patente)
                  .WithMany(patente => patente.Militares)
                  .HasForeignKey(militar => militar.PatenteId)
                  .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(militar => militar.Batalhao)
                  .WithMany(batalhao => batalhao.Militares)
                  .HasForeignKey(militar => militar.BatalhaoId)
                  .OnDelete(DeleteBehavior.SetNull);     

            entity.Property(militar => militar.DataNascimento)
                  .HasColumnName("data_nascimento");
        });


        modelBuilder.Entity<Patente>(entity => {
            entity.HasKey(patente => patente.Id);

            entity.Property(patente => patente.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd();

            entity.Property(patente => patente.Graduacao)
                  .HasColumnName("graduacao")
                  .HasMaxLength(64);
        });

        modelBuilder.Entity<Batalhao>(entity => {
            entity.HasKey(batalhao => batalhao.Id);

            entity.Property(batalhao => batalhao.Id)
                  .HasColumnName("id")
                  .ValueGeneratedOnAdd();

            entity.Property(batalhao => batalhao.Identificacao)
                  .HasColumnName("identificacao")
                  .HasMaxLength(64);
        });
    }
}
