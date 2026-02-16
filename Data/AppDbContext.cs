using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Ruang> Ruang { get; set; }
    public DbSet<Peminjaman> Peminjaman { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Ruang>().HasData(
            new Ruang { Id = 1, Name = "D3 Teather", Capacity = 120 },
            new Ruang { Id = 2, Name = "Auditorium Pasca Lt.6", Capacity = 500 },
            new Ruang { Id = 3, Name = "Ruang Rapat Pasca Lt.1", Capacity = 30 },
            new Ruang { Id = 4, Name = "Mini Teather Pasca Lt.6", Capacity = 120 },
            new Ruang { Id = 5, Name = "Hall D4", Capacity = 300 }
        );
    }
}
