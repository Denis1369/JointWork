using System;
using System.Collections.Generic;

namespace Dent.Model;

public partial class Manager
{
    public int ManagerId { get; set; }

    public string ManagerPassword { get; set; } = null!;
}
