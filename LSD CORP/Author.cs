using System;
using System.Collections.Generic;

namespace LSD_CORP;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int IdCountry { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    public virtual Country IdCountryNavigation { get; set; } = null!;
}
