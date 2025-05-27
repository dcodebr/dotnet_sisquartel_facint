using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisQuartel.Api.Models;
using SisQuartel.Api.Repositories;

namespace SisQuartel.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatenteController : ControllerBase
{
    public SisQuartelContext Context { get; set; }
    public DbSet<Patente> Patentes => Context.Patentes;

    public PatenteController(SisQuartelContext dbcontext)
    {
        Context = dbcontext;
    }


    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var resultado = await Patentes.ToArrayAsync();
        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetornarPorId(int id)
    {
        var result = await Patentes.FirstOrDefaultAsync(b => b.Id == id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Incluir(Patente patente)
    {
        await Patentes.AddAsync(patente);
        await Context.SaveChangesAsync();

        return Ok(patente);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Patente patente)
    {
        var entity = await Patentes.FirstOrDefaultAsync(b => b.Id == id);

        if (entity is null)
        {
            return NotFound();
        }

        patente.Id = entity.Id;

        Context.Entry(entity).CurrentValues.SetValues(patente);
        await Context.SaveChangesAsync();

        return Ok(entity);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(long id)
    {
        var entity = await Patentes.FirstOrDefaultAsync(b => b.Id == id);

        if (entity is null)
        {
            return NotFound();
        }

        Patentes.Remove(entity);
        await Context.SaveChangesAsync();
        return Ok();
    }
}
