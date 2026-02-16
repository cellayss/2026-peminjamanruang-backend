using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class RuanganService
{
    private readonly AppDbContext _context;

    public RuanganService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Ruang>> GetAll()
    {
        return await _context.Ruang.ToListAsync();
    }

    public async Task<Ruang?> GetById(int id)
    {
        return await _context.Ruang.FindAsync(id);
    }

    public async Task<Ruang> Create(Ruang ruang)
    {
        _context.Ruang.Add(ruang);
        await _context.SaveChangesAsync();
        return ruang;
    }

    public async Task<Ruang?> Update(int id, Ruang ruang)
    {
        var data = await _context.Ruang.FindAsync(id);
        if (data == null) return null;

        data.Name = ruang.Name;
        data.Capacity = ruang.Capacity;

        await _context.SaveChangesAsync();
        return data;
    }

    public async Task<bool> Delete(int id)
    {
        var data = await _context.Ruang.FindAsync(id);
        if (data == null) return false;

        _context.Ruang.Remove(data);
        await _context.SaveChangesAsync();
        return true;
    }
}
