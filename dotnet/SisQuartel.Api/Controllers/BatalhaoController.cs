using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisQuartel.Api.Models;
using SisQuartel.Api.Repositories;

namespace SisQuartel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BatalhaoController : ControllerBase
{
    public SisQuartelContext Context { get; set; }
    public DbSet<Batalhao> Batalhoes => Context.Batalhoes;

    public BatalhaoController(SisQuartelContext dbcontext)
    {
        Context = dbcontext;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var resultado = await Batalhoes.ToArrayAsync();
        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetornarPorId(int id)
    {
        var result = await Batalhoes.FirstOrDefaultAsync(b => b.Id == id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Incluir(Batalhao batalhao)
    {
        await Batalhoes.AddAsync(batalhao);
        await Context.SaveChangesAsync();

        return Ok(batalhao);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Batalhao batalhao)
    {
        var entity = await Batalhoes.FirstOrDefaultAsync(b => b.Id == id);

        if (entity is null)
        {
            return NotFound();
        }

        batalhao.Id = entity.Id;

        Context.Entry(entity).CurrentValues.SetValues(batalhao);
        await Context.SaveChangesAsync();

        return Ok(entity);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(long id)
    {
        var entity = await Batalhoes.FirstOrDefaultAsync(b => b.Id == id);

        if (entity is null)
        {
            return NotFound();
        }

        Batalhoes.Remove(entity);
        await Context.SaveChangesAsync();
        return Ok();
    }
}
