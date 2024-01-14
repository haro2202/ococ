using System;
using System.Collections.Generic;

namespace ococ.Models;

public partial class Hanhkhach
{
    public string Mahk { get; set; } = null!;

    public string? Hoten { get; set; }

    public string? Diachi { get; set; }

    public string? Dienthoai { get; set; }

    public virtual ICollection<CtCb> CtCbs { get; set; } = new List<CtCb>();
}
