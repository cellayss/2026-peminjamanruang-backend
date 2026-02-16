using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class PeminjamanService
{
    private readonly AppDbContext _context;

    public PeminjamanService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Peminjaman>> GetAll()
    {
        return await _context.Peminjaman.Include(b => b.Ruang).ToListAsync();
    }

    public async Task<Peminjaman?> GetById(int id)
    {
        return await _context.Peminjaman.Include(b => b.Ruang)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Peminjaman> Create(Peminjaman peminjaman)
    {
        _context.Peminjaman.Add(peminjaman);
        await _context.SaveChangesAsync();
        return peminjaman;
    }
}
