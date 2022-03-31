﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.ViewModels
{
    public record NamedColors(string RgbCode, string HexCode, string Name, int ColorType, bool Available)
    {

    }
}
