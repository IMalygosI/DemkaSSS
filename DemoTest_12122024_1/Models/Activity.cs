using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class Activity
{
    public int ActivityId { get; set; }

    public string ActivityName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
