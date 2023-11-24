using Domain.Entities;

namespace API.Dtos;
public class G_PhaseDto
{
    public int Id { get; set; }

    public string Phase { get; set; } = null!;
    public virtual PVerbalTenseDescriptionDto VerbalTense { get; set; } = null!;
    public virtual PStructureDescriptionDto Structure { get; set; } = null!;
    public virtual PTypeDescriptionDto Type { get; set; } = null!;

}