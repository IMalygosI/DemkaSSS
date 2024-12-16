using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class TagOfClient
{
    public int ClientId { get; set; }

    public int TagId { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Tag Tag { get; set; } = null!;
}
