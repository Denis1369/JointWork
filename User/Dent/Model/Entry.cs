using System;
using System.Collections.Generic;

namespace Dent.Model;

public partial class Entry
{
    public int EntryId { get; set; }

    public DateTime? DateTime { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public string? EntryStatus { get; set; }

}
