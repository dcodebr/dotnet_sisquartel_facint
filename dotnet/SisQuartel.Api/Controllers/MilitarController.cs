using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisQuartel.Api.Models;
using SisQuartel.Api.Repositories;

namespace SisQuartel.Api.Controllers;

//
//GET - READ
//POST - CREATE
//PUT - UPDATE
//DELETE - DELETE

[ApiController]
[Route("/api/militares")]
public class MilitarController : ControllerBase
{
    public SisQuartelContext Context { get; set; }
    public DbSet<Militar> Militares => Context.Militares;

    public MilitarController(SisQuartelContext dbContext)
    {
        Context = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        var resultado = await Militares.ToArrayAsync();
        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RetornarPorId(int id)
    {
        var result = await Militares.FirstOrDefaultAsync(b => b.Id == id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Incluir(Militar militar)
    {
        await Militares.AddAsync(militar);
        await Context.SaveChangesAsync();

        return Ok(militar);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(int id, Militar militar)
    {
        var entity = await Militares.FirstOrDefaultAsync(b => b.Id == id);

        if (entity is null)
        {
            return NotFound();
        }

        militar.Id = entity.Id;

        Context.Entry(entity).CurrentValues.SetValues(militar);
        await Context.SaveChangesAsync();

        return Ok(entity);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Excluir(long id)
    {
        var entity = await Militares.FirstOrDefaultAsync(b => b.Id == id);

        if (entity is null)
        {
            return NotFound();
        }

        Militares.Remove(entity);
        await Context.SaveChangesAsync();
        return Ok();
    }
}