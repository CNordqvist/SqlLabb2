using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Böcker> Böckers { get; } = new List<Böcker>();
}
