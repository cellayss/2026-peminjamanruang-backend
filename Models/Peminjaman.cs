namespace Backend.Models;

public class Peminjaman
{
    public int Id { get; set; }
    public string BorrowerName { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public string Status { get; set; } = "Pending";

    public int RuangId { get; set; }
    public Ruang? Ruang { get; set; }
}
