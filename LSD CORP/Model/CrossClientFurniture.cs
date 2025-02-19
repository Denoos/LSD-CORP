using System;
using System.Collections.Generic;

namespace LSD_CORP;

public partial class CrossClientFurniture
{
    public int IdClient { get; set; }

    public int IdFurniture { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Furniture IdFurnitureNavigation { get; set; } = null!;
}
