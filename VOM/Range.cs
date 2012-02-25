///<Licence>
/// Copyright (c) Steven Houben: http://anxma.com 
/// 
/// This library is free software; you can redistribute it and/or modify it
/// under the terms of the GNU GENERAL PUBLIC LICENSE V3 or later, as
/// published by the Free Software Foundation. Check 
/// http://www.gnu.org/licenses/gpl.html for details.
/// </Licence>
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VOM
{
    public class Range
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public int Difference
        {
            get { return Max - Min; }
        }
        public Range() { }
        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
