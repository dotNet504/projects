﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asx_Assign5
{
    public class Pieces
    {
        public string Name { get; set; }
        public Image Icon { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool? isPositionChanged { get; set; }
    }
}
