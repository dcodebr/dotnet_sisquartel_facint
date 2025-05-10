# SisQuartel - Sistema de Gestão para Quartéis Militares da Faculdade FACINT

Sistema de gestão para quarteis militares desenvolvido em conjunto aos alunos dos cursos de tecnologia da Faculdade FACINT. O sistema foi desenvolvido com o framework dotnet com Entity Framework Core, banco de dados MySQL 8.0 e Swagger.

Você pode assistir a gravação da aula ao vivo em que o projeto é construído clicando no link a seguir:

[![Projeto e Modelagem de Dados - ao vivo - 06/05/2025 - Alex Rocha](https://img.youtube.com/vi/GqWcfdYWXA8/0.jpg)](https://www.youtube.com/watch?v=GqWcfdYWXA8)

## Instalação e Configuração do Ambiente

Para executar o projeto, é necessário ter instalado e configurado em seu computador o dotnet SDK, o Microsoft VS Code para projetos dotnet e o MySQL na versão 8.0. A seguir você poderá acompanhar as instruções para instalação e configuração dessas ferramentas utilizadas.

### Instalação do SDK e configuração do Microsoft VS Code

O dotnet SDK utilizada para construção do projeto é o da versão 8.0. Você pode baixar essa versão do SDK para os principais sistemas operacionais através [deste link](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

A ferramenta utilizada para o desenvolvimento do app é o [Microsoft VS Code](https://code.visualstudio.com/Download). As extensões necessárias para a programação são:

- [.NET Install Tool](https://marketplace.visualstudio.com/items/?itemName=ms-dotnettools.vscode-dotnet-runtime)
- [C#](https://marketplace.visualstudio.com/items/?itemName=ms-dotnettools.csharp)
- [C# Extensions](https://marketplace.visualstudio.com/items/?itemName=kreativ-software.csharpextensions)
- [vscode-solution-explorer](https://marketplace.visualstudio.com/items/?itemName=fernandoescolar.vscode-solution-explorer)
 
Você também pode assistir ao vídeo contendo as orientações para instalação e configuração do ambiente dotnet para o VS Code:

[![Configurando VS Code com C# .Net SDK](https://img.youtube.com/vi/YEtisxQugew/0.jpg)](https://www.youtube.com/watch?v=YEtisxQugew)


### Instalação do MySQL Community

O banco de dados acessado pela aplicação é gerenciado pelo MySQL Community na versão 8.0. Será necessário ter acesso a um servidor remoto ou mesmo instalar o SGBD localmente, em seu computador. Para isso, você pode baixar o instalador do MySQL Community através [deste link](https://dev.mysql.com/downloads/).

## Dependências do Projeto

O projeto depende de cinco dependências de terceiros e suas respectivas versões:

- [Microsoft.EntityFrameworkCore - 8.0.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/8.0.15)
- [Microsoft.EntityFrameworkCore.Tools - 8.0.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/8.0.15)
- [Microsoft.EntityFrameworkCore.Design - 8.0.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/8.0.15)
- [Microsoft.EntityFrameworkCore.Proxies - 8.0.15](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Proxies/8.0.15)
- [Pomelo.EntityFrameworkCore.MySql - 8.0.3](https://www.nuget.org/packages/Pomelo.EntityFrameworkCore.MySql/8.0.3)

Há também a necessidade da instalação, em nível global, do pacote [dotnet-ef](https://www.nuget.org/packages/dotnet-ef). Esse pacote é responsável pela realização do gerenciamento das entidades do Entity Framework, em especial realizar o Migrations.

```sh
dotnet tool install --global dotnet-ef
```

## Execução do Migrations

O Migrations é processo de persistência das alterações do modelo de Entidades para o banco de dados real. A cada alteração no modelo, você deve executar a adição do migrations, semelhante ao que fazemos com as alterações do Git/GitHub. Para isso, digite:

```sh
dotnet ef migrations add "Initial Migrations"
```

Ao executar, um novo conjunto de arquivos será criado contendo as instruções de alteração do banco de dados. Para persistir as alterações, você deve executar:

```sh
dotnet ef database update
```

## Trechos importantes

Os trechos mais importantes do projeto são referentes aos Models, Repositories e Controllers. Veja a seguir:

[**Models: Militar.cs**](./dotnet/SisQuartel.Api/Models/Militar.cs)

```csharp
public class Militar
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Patente { get; set; }
    public string? Batalhao { get; set; }
    public DateTime? DataNascimento { get; set; }
}
```

[**Repositories: SisQuartelContext.cs**](./dotnet/SisQuartel.Api/Repositories/SisQuartelContext.cs)

```csharp
public class SisQuartelContext : DbContext
{
    public DbSet<Militar> Militares { get; set; }

    public SisQuartelContext(DbContextOptions<SisQuartelContext> options)
          : base(options) { }

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
```

[**Repositories: SisQuartelContextFactory.cs**](./dotnet/SisQuartel.Api/Repositories/SisQuartelContextFactory.cs)

```csharp
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
```

[**Controllers: SisQuartelContextFactory.cs**](./dotnet/SisQuartel.Api/Repositories/SisQuartelContextFactory.cs)

```csharp
[ApiController]
[Route("api/[controller]")]
public class MilitarController : ControllerBase
{
    public SisQuartelContext context { get; set; }
    public DbSet<Militar> Militares => context.Militares;

    public MilitarController(SisQuartelContext dbcontext)
    {
        this.context = dbcontext;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var resultado = await Militares.ToArrayAsync();
        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Incluir(Militar militar)
    {
        await Militares.AddAsync(militar);
        await context.SaveChangesAsync();
        
        return Ok();
    }
}
```

[**Program.cs**](./dotnet/SisQuartel.Api/Program.cs)

```csharp
//[…]
builder.Services.AddTransient<SisQuartelContextFactory>();
builder.Services.AddTransient(opt => opt.GetService<SisQuartelContextFactory>()!.CreateDbContext());
//[…]
```

---
Desenvolvido por Alex Rocha