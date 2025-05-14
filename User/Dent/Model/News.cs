using System;
using System.Collections.Generic;

namespace Dent.Model;

public partial class News
{
    public int NewsId { get; set; }

    public string? NewsTitle { get; set; }

    public string? NewsDesc { get; set; }

    public DateOnly? DatePublish { get; set; }

    public byte[]? NewsImage { get; set; }

    public byte[]? DisplayedImage => NewsImage;
}
