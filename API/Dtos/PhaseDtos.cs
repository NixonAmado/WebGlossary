using Domain.Entities;

namespace API.Dtos;
public class G_PhaseDto
{
    public int Id { get; set; }

    public string Phase1 { get; set; } = null!;
    public virtual PVerbalTenseDescriptionDto PhaseVerbalTense { get; set; } = null!;
    public virtual PStructureDescriptionDto PhaseStructure { get; set; } = null!;
    public virtual PTypeDescriptionDto PhaseType { get; set; } = null!;

}