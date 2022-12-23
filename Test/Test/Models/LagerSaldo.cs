using System;
using System.Collections.Generic;

namespace Test.Models;

public partial class LagerSaldo
{
    public int ButikId { get; set; }

    public string Isbn13 { get; set; } = null!;

    public int? Antal { get; set; }
}
