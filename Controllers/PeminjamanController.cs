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
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Create(Peminjaman peminjaman)
    {
        return Ok(await _service.Create(peminjaman));
    }
}
