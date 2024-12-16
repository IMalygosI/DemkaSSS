using System;
using System.Collections.Generic;

namespace DemoTest_12122024_1.Models;

public partial class ProductSale
{
    public int ProductSaleId { get; set; }

    public DateOnly? ProductsaleSaleDate { get; set; }

    public int? ProductsaleProductId { get; set; }

    public int? ProductsaleQuantity { get; set; }

    public int? ClientServiceId { get; set; }

    public virtual ClientService? ClientService { get; set; }

    public virtual Product? ProductsaleProduct { get; set; }
}
