using System;
using System.Collections.Generic;

namespace ococ.Models;

public partial class CtCb
{
    public string Mach { get; set; } = null!;

    public string Mahk { get; set; } = null!;

    public string? Soghe { get; set; }

    public bool? Loaighe { get; set; }

    public virtual Chuyenbay ChuyenBay { get; set; } = null!;

    public virtual Hanhkhach HanhKhach { get; set; } = null!;
}
