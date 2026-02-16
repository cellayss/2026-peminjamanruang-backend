using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using Backend.DTO;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RuanganController : ControllerBase
{
    private readonly AppDbContext _context;

    public RuanganController(AppDbContext context)
    {
        _context = context;
    }

    // READ ALL
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Ruang.ToList());
    }

    // READ BY ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var ruang = _context.Ruang.Find(id);
        if (ruang == null) return NotFound();

        return Ok(ruang);
    }

    // CREATE
    [HttpPost]
    public IActionResult Create(RuangCreateDto dto)
    {
        var ruang = new Ruang
        {
            Name = dto.Name,
            Capacity = dto.Capacity
        };

        _context.Ruang.Add(ruang);
        _context.SaveChanges();

        return Ok(ruang);
    }

    // UPDATE
    [HttpPut("{id}")]
    public IActionResult Update(int id, RuangCreateDto dto)
    {
        var ruang = _context.Ruang.Find(id);
        if (ruang == null) return NotFound();

        ruang.Name = dto.Name;
        ruang.Capacity = dto.Capacity;

        _context.SaveChanges();

        return Ok(ruang);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var ruang = _context.Ruang.Find(id);
        if (ruang == null) return NotFound();

        _context.Ruang.Remove(ruang);
        _context.SaveChanges();

        return Ok("Deleted");
    }
}
