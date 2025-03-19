using System;
using System.Collections.Generic;

namespace LSD_CORP;

public partial class Country
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
