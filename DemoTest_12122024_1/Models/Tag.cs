using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class Tag
{
    public int TagId { get; set; }

    public string TagTitle { get; set; } = null!;

    public string TagColor { get; set; } = null!;

    public virtual ICollection<TagOfClient> TagOfClients { get; set; } = new List<TagOfClient>();
}
