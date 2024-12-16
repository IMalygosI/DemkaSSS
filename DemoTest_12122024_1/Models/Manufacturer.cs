using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string ManufacturerName { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
