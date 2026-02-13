using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Ruang> Ruangan => Set<Ruang>();
    public DbSet<Peminjaman> Peminjamans => Set<Peminjaman>();
}
