using System;
using System.Collections.Generic;

namespace SqlLabb2.Models;

public partial class Publisher
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Böcker> Böckers { get; } = new List<Böcker>();
}
