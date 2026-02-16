using Backend.DTO;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeminjamanController : ControllerBase
{
    private readonly PeminjamanService _service;

    public PeminjamanController(PeminjamanService service)
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
    public async Task<IActionResult> Create(PeminjamanCreateDto dto)
    {
        var peminjaman = new Peminjaman
        {
            BorrowerName = dto.BorrowerName,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            RuangId = dto.RuangId
        };

        var result = await _service.Create(peminjaman);

        if (result == null)
            return BadRequest("Ruang tidak ditemukan");

        return Ok(result);
    }

    [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(
        int id,
        [FromBody] UpdateStatusDto dto
        )
    {

        var data = await _service.UpdateStatus(id, dto.Status);
        if (data == null) return NotFound();

        return Ok(data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Peminjaman dto)
    {
    var result = await _service.Update(id, dto);
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
