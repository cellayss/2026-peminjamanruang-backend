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
        return await _context.Peminjaman
            .Include(x => x.Ruang)
            .ToListAsync();
    }

    public async Task<Peminjaman?> GetById(int id)
    {
        return await _context.Peminjaman
            .Include(x => x.Ruang)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Peminjaman?> Create(Peminjaman peminjaman)
    {
        var ruang = await _context.Ruang.FindAsync(peminjaman.RuangId);
        if (ruang == null) return null;

        peminjaman.Status = PeminjamanStatus.Pending;

        _context.Peminjaman.Add(peminjaman);
        await _context.SaveChangesAsync();

        return peminjaman;
    }

   public async Task<Peminjaman?> Update(int id, Peminjaman updatedData)
    {
    var existing = await _context.Peminjaman.FindAsync(id);
    if (existing == null) return null;

    existing.BorrowerName = updatedData.BorrowerName;
    existing.RuangId = updatedData.RuangId;
    existing.StartTime = updatedData.StartTime;
    existing.EndTime = updatedData.EndTime;

    await _context.SaveChangesAsync();

    return existing;
    }

    public async Task<Peminjaman?> UpdateStatus(int id, PeminjamanStatus status)
    {
        var data = await _context.Peminjaman.FindAsync(id);
        if (data == null) return null;

        data.Status = status;
        await _context.SaveChangesAsync();

        return data;
    }

    public async Task<bool> Delete(int id)
    {
        var data = await _context.Peminjaman.FindAsync(id);
        if (data == null) return false;

        _context.Peminjaman.Remove(data);
        await _context.SaveChangesAsync();
        return true;
    }
}
