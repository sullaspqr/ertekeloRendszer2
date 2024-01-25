using System;
using System.Collections.Generic;

namespace ertekeloRendszer.Models;

public partial class Screening
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public virtual ICollection<Ertekelesek> Ertekeleseks { get; } = new List<Ertekelesek>();
}
