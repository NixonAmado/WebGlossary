using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Phasetype
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Phase> Phases { get; set; } = new List<Phase>();
}
