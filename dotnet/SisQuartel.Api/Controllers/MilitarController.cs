using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SisQuartel.Api.Models;
using SisQuartel.Api.Repositories;

namespace SisQuartel.Api.Controllers;

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
