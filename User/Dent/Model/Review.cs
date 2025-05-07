using System;
using System.Collections.Generic;

namespace Dent.Model;

public partial class Review
{
    public int ReviewsId { get; set; }

    public DateTime? ReviewsDate { get; set; }

    public string? ReviewsText { get; set; }
}
