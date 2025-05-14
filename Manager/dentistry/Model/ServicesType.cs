using System;
using System.Collections.Generic;

namespace dentistry.Model;

public partial class ServicesType
{
    public int ServicesTypeId { get; set; }

    public string? ServicesTypeTitle { get; set; }

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
