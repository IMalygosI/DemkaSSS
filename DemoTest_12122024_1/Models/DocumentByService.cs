using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class DocumentByService
{
    public int DocumentByServiceId { get; set; }

    public int ClientserviceId { get; set; }

    public string? DocumentPath { get; set; }

    public virtual ClientService Clientservice { get; set; } = null!;
}
