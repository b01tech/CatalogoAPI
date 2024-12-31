using CatalogoAPI.Data;
using CatalogoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoAPI.Controllers;
[Route("[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{    
    private readonly AppDbContext _context;

    public CategoriaController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var categorias = _context.Categorias.ToList();

        if (categorias is null)
        {
            return NotFound("Nenhuma categoria encontrada");
        }
        return Ok(categorias);
    }
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var categoria = _context.Categorias.Find(id);
        if (categoria is null)
        {
            return NotFound($"Categoria com id={id} não encontrada");
        }
        return Ok(categoria);
    }

    [HttpPost]
    public IActionResult Post(Categoria categoria)
    {
        if (categoria is not null)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return Created(string.Empty, categoria);
        }
        return BadRequest();

    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Categoria categoria)
    {
        if (categoria.CategoriaId == id)
        {
            _context.Update(categoria);
            _context.SaveChanges();
            return Ok(categoria);
        }

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var categoria = _context.Categorias.Find(id);

        if (categoria is not null)
        {
            _context.Categorias.Remove(categoria);
            _context.SaveChanges();
            return Ok();
        }
        return NotFound("Categoria não encontrada.");
    }
}
