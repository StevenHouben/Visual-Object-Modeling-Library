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

namespace VOM
{
    public enum Modes
    {
        NONE,
        DRAWMODE,
        DRAGMODE,
        SHAPEMODE
    }
    public enum DrawMode
    {
        SELECTIONRECTANGLE,
        POLYGON,
        BOTH
    }
    public enum Type
    {
        POLYGON,
        ELLIPSE
    }
}
