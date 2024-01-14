using System;
using System.Collections.Generic;

namespace ococ.Models;

public partial class Maybay
{
    public string Mamb { get; set; } = null!;

    public string? Hangmb { get; set; }

    public int? Socho { get; set; }

    public virtual ICollection<Chuyenbay> Chuyenbays { get; set; } = new List<Chuyenbay>();
}
