using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class Gender
{
    public string? GenderName { get; set; }

    public int GenderCode { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
