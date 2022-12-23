using System;
using System.Collections.Generic;

namespace SqlLabb2.Models;

public partial class Butiker
{
    public int Id { get; set; }

    public string? Namn { get; set; }

    public string? KontaktMail { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Ordrar> Ordrars { get; } = new List<Ordrar>();
}
