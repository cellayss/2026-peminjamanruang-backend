namespace Backend.DTO;

public class PeminjamanCreateDto
{
    public string BorrowerName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int RuangId { get; set; }
}
