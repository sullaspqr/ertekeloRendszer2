using System;
using System.Collections.Generic;

namespace ertekeloRendszer.Models;

public partial class Getter
{
    public string Nev { get; set; } = null!;

    public int Pontertek { get; set; }

    public int Szorzo { get; set; }

    public string SzempontNev { get; set; } = null!;

    public long VégsőPont { get; set; }
}
