using System;
using System.Collections.Generic;

namespace SqlLabb2.Models;

public partial class Ordrar
{
    public int OrderId { get; set; }

    public int ButikId { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? Isbn13 { get; set; }

    public int? Kvantitet { get; set; }

    public virtual Butiker Butik { get; set; } = null!;

    public virtual Böcker? Isbn13Navigation { get; set; }
}
