using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Word
{
    public int Id { get; set; }

    public string WordText { get; set; } = null!;

    public int WordTypeId { get; set; }

    public sbyte Plural { get; set; }

    public int VerbalTenseId { get; set; }

    public string? Translation { get; set; }

    public virtual Verbaltense VerbalTense { get; set; } = null!;

    public virtual Wordtype VerbalTenseNavigation { get; set; } = null!;
}
