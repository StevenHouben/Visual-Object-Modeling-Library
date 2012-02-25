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

namespace VOM
{
    public class DrawRectangle{
        private Point startPoint;
        public Point StartPoint 
        {
            get { return startPoint; }
            set
            {
                this.startPoint = value;
                this.Size = new Size(this.endPoint.X - this.startPoint.X, this.endPoint.Y - this.startPoint.Y);
            }
        }
        private Point endPoint;
        public Point EndPoint{
            get { return endPoint; }
            set
            {
                this.endPoint = value;
                this.Size = new Size(this.endPoint.X - this.startPoint.X, this.endPoint.Y - this.startPoint.Y);
            }
        }
        public Size Size { get; set; }
    }
}
