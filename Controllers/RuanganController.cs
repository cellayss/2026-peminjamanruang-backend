using Backend.DTO;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RuanganController : ControllerBase
{
    private readonly RuanganService _service;

    public RuanganController(RuanganService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await _service.GetById(id);
        if (data == null) return NotFound();

        return Ok(data);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RuangCreateDto dto)
    {
        var ruang = new Ruang
        {
            Name = dto.Name,
            Capacity = dto.Capacity
        };

        return Ok(await _service.Create(ruang));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RuangCreateDto dto)
    {
        var ruang = new Ruang
        {
            Name = dto.Name,
            Capacity = dto.Capacity
        };

        var result = await _service.Update(id, ruang);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.Delete(id);
        if (!success) return NotFound();

        return Ok("Deleted");
    }
}
