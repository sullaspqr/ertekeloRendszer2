﻿using System;
using System.Collections.Generic;

namespace ertekeloRendszer.Models;

public partial class Ertekelesek
{
    public int Id { get; set; }

    public int ScreeningId { get; set; }

    public int SzempontId { get; set; }

    public int Pontertek { get; set; }
}
