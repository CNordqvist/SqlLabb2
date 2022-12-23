using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class Böcker
{
    public string Isbn13 { get; set; } = null!;

    public string? Title { get; set; }

    public string? Språk { get; set; }

    public decimal? Pris { get; set; }

    public DateTime? PublishingDate { get; set; }

    public int FörfattarId { get; set; }

    public int PubId { get; set; }

    public int GenreId { get; set; }

    public virtual Författare Författar { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<Ordrar> Ordrars { get; } = new List<Ordrar>();

    public virtual Publisher Pub { get; set; } = null!;
}
