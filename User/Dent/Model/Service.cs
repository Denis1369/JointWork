using System;
using System.Collections.Generic;

namespace Dent.Model;

public partial class Service
{
    public int ServicesId { get; set; }

    public string? ServicesTitle { get; set; }

    public string? ServicesDesc { get; set; }

    public int? ServicesPrice { get; set; }

    public int? ServicesTypeId { get; set; }

    public virtual ServicesType? ServicesType { get; set; }
}
