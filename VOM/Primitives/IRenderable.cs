///<Licence>
/// Copyright (c) Steven Houben: http://anxma.com 
/// 
/// This library is free software; you can redistribute it and/or modify it
/// under the terms of the GNU GENERAL PUBLIC LICENSE V3 or later, as
/// published by the Free Software Foundation. Check 
/// http://www.gnu.org/licenses/gpl.html for details.
/// </Licence>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VOM.Primitives
{
    public interface IRenderable
    {
        Point[] Corners { get; set; }
        Color FillColor { get; set; }
        int Alpha { get; set; }
        bool IsSelected { get; set; }
        Point DragPoint { get; set; }
        string Name { get; set; }
        int Tag { get; set; }
        int SelectedCorner { get; set; }
        Type Type { get; set; }
    }
}
