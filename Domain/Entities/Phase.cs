using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Phase
{
    public int Id { get; set; }

    public string Phase1 { get; set; } = null!;

    public int PhaseTypeId { get; set; }

    public int PhaseStructureId { get; set; }

    public int PhaseVerbalTenseId { get; set; }

    public string Translation { get; set; } = null!;

    public virtual Phasestructure PhaseStructure { get; set; } = null!;

    public virtual Phaseverbaltense PhaseStructureNavigation { get; set; } = null!;

    public virtual Phasetype PhaseType { get; set; } = null!;
}
