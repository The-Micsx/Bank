using System;
using System.Collections.Generic;

namespace Bank.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int RoleId { get; set; }

    public int HomeAdres { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual HomeAdre HomeAdresNavigation { get; set; } = null!;

    public virtual UserRole Role { get; set; } = null!;
}
