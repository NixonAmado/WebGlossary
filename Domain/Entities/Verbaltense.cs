using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Verbaltense
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Word> Words { get; set; } = new List<Word>();
}
