using System;
using System.Collections.Generic;

namespace LSD_CORP;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int IdAuthor { get; set; }

    public int IdGenre { get; set; }

    public DateOnly DateCreate { get; set; }

    public virtual Author IdAuthorNavigation { get; set; } = null!;

    public virtual Genre IdGenreNavigation { get; set; } = null!;
}
