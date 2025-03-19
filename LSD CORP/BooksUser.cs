using System;
using System.Collections.Generic;

namespace LSD_CORP;

public partial class BooksUser
{
    public int IdBook { get; set; }

    public int IdUser { get; set; }

    public virtual Book IdBookNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
