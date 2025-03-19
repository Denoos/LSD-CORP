using System;
using System.Collections.Generic;

namespace LSD_CORP;

public partial class User
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;
}
