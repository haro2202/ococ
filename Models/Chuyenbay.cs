using System;
using System.Collections.Generic;

namespace ococ.Models;

public partial class Chuyenbay
{
    public string Mach { get; set; } = null!;

    public string? Chuyen { get; set; }

    public string? Ddi { get; set; }

    public string? Dden { get; set; }

    public string? Ngay { get; set; }

    public string? Gbay { get; set; }

    public string? Gden { get; set; }

    public int? Thuong { get; set; }

    public int? Vip { get; set; }

    public string? Mamb { get; set; }

    public virtual ICollection<CtCb> CtCbs { get; set; } = new List<CtCb>();

    public virtual Maybay? Maybay { get; set; }
}
