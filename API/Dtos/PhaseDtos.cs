using Domain.Entities;

namespace API.Dtos;
public class G_PhaseDto
{
    public int Id { get; set; }

    public string Phase { get; set; } = null!;
    public virtual string VerbalTense { get; set; } = null!;
    public virtual string Structure { get; set; } = null!;
    public virtual string Type { get; set; } = null!;

}