using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class ClientService
{
    public int ClientserviceId { get; set; }

    public int ClientserviceClientId { get; set; }

    public int ClientserviceServiceId { get; set; }

    public DateOnly ClientserviceStartTime { get; set; }

    public string? ClientserviceComment { get; set; }

    public virtual Client ClientserviceClient { get; set; } = null!;

    public virtual Service ClientserviceService { get; set; } = null!;

    public virtual ICollection<DocumentByService> DocumentByServices { get; set; } = new List<DocumentByService>();

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
