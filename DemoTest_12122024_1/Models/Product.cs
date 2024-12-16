using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductTitle { get; set; } = null!;

    public decimal ProductCost { get; set; }

    public string ProductDescription { get; set; } = null!;

    public string? ProductMainImage { get; set; }

    public int? ActiveId { get; set; }

    public int? ManufacturerId { get; set; }

    public virtual Activity? Active { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
    public Bitmap Picture => ProductMainImage != null ? new Bitmap($@"Asset/{ProductMainImage}") : null;
}
