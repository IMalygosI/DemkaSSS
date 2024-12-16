using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string ServiceTitle { get; set; } = null!;

    public decimal ServiceCost { get; set; }

    public int ServiceDurationinSeconds { get; set; }

    public string? ServiceDescription { get; set; }

    public string? ServiceDiscount { get; set; }

    public string? ServiceMainimagePath { get; set; }

    public virtual ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();

    public virtual ServicePhoto? ServicePhoto { get; set; }
}
