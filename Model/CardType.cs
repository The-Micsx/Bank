using System;
using System.Collections.Generic;

namespace Bank.Model;

public partial class CardType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
}
