using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Backend.Models;
using Backend.DTO;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeminjamanController : ControllerBase
{
    private readonly AppDbContext _context;

    public PeminjamanController(AppDbContext context)
    {
        _context = context;
    }

    // READ ALL
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Peminjaman.Include(x => x.Ruang).ToList());
    }

    // READ BY ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var data = _context.Peminjaman
            .Include(x => x.Ruang)
            .FirstOrDefault(x => x.Id == id);

        if (data == null) return NotFound();

        return Ok(data);
    }

    // CREATE
    [HttpPost]
    public IActionResult Create(PeminjamanCreateDto dto)
    {
        var ruang = _context.Ruang.Find(dto.RuangId);
        if (ruang == null) return BadRequest("Ruang tidak ditemukan");

        var peminjaman = new Peminjaman
        {
            BorrowerName = dto.BorrowerName,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            Status = PeminjamanStatus.Pending,
            RuangId = dto.RuangId
        };

        _context.Peminjaman.Add(peminjaman);
        _context.SaveChanges();

        return Ok(peminjaman);
    }

    // UPDATE STATUS
    [HttpPut("{id}")]
    public IActionResult UpdateStatus(int id, PeminjamanStatus status)
    {
        var data = _context.Peminjaman.Find(id);
        if (data == null) return NotFound();

        data.Status = status;
        _context.SaveChanges();

        return Ok(data);
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var data = _context.Peminjaman.Find(id);
        if (data == null) return NotFound();

        _context.Peminjaman.Remove(data);
        _context.SaveChanges();

        return Ok("Deleted");
    }
}
