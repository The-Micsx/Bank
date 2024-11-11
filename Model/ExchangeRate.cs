using System;
using System.Collections.Generic;

namespace Bank.Model;

public partial class ExchangeRate
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }
}
