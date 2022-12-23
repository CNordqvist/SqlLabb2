using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class TitlarPerFörfattare
{
    public string Namn { get; set; } = null!;

    public int? Ålder { get; set; }

    public int? BokMängd { get; set; }

    public decimal? LagerVärde { get; set; }
}
