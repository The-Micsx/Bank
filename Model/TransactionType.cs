using System;
using System.Collections.Generic;

namespace Bank.Model;

public partial class TransactionType
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<TransactionHistory> TransactionHistories { get; set; } = new List<TransactionHistory>();
}
