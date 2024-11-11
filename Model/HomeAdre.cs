using System;
using System.Collections.Generic;

namespace Bank.Model;

public partial class HomeAdre
{
    public int Id { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Adres { get; set; }

    public string? Home { get; set; }

    public int? Apartment { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
