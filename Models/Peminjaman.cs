namespace Backend.Models;

public enum PeminjamanStatus
{
    Pending,
    Approved,
    Rejected,
    Completed
}

public class Peminjaman
{
    public int Id { get; set; }
    public string BorrowerName { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public PeminjamanStatus Status { get; set; } = PeminjamanStatus.Pending;

    public int RuangId { get; set; }
    public Ruang? Ruang { get; set; }
}
