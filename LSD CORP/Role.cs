using System;
using System.Collections.Generic;

namespace LSD_CORP;

public partial class Role
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AccessLevel { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
