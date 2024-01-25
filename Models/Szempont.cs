using System;
using System.Collections.Generic;

namespace ertekeloRendszer.Models;

public partial class Szempont
{
    public int Id { get; set; }

    public string SzempontNev { get; set; } = null!;

    public int Szorzo { get; set; }

    public virtual ICollection<Ertekelesek> Ertekeleseks { get; } = new List<Ertekelesek>();
}
