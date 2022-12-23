﻿using System;
using System.Collections.Generic;

namespace SqlLabb2.Models;

public partial class Författare
{
    public int Id { get; set; }

    public string? Förnamn { get; set; }

    public string? Efternamn { get; set; }

    public DateTime? Födelsedatum { get; set; }

    public virtual ICollection<Böcker> Böckers { get; } = new List<Böcker>();
}
