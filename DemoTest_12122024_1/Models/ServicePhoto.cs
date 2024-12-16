using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class ServicePhoto
{
    public int ServiceId { get; set; }

    public int ServicePhotoId { get; set; }

    public string ServicephotoPhotoPath { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
