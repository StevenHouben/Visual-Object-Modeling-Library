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
using System.ComponentModel;

namespace VOM.Primitives
{
    public class Polygon:IRenderable
    {
        [CategoryAttribute("Polygon")]
        public Point[] Corners { get; set; }
        [CategoryAttribute("Polygon")]
        public Color FillColor { get; set; }
        [CategoryAttribute("Polygon")]
        public bool IsSelected { get; set; }
        [CategoryAttribute("Polygon")]
        public Point DragPoint { get; set; }
        [CategoryAttribute("Polygon")]
        public string Name { get; set; }
        [CategoryAttribute("Polygon")]
        public int Tag { get; set; }
        [CategoryAttribute("Polygon")]
        public int SelectedCorner { get; set; }
        [CategoryAttribute("Polygon")]
        public Type Type { get; set; }
        [CategoryAttribute("Polygon")]
        public int Alpha { get; set; }

        public Polygon()
        {
            Initialize();
            this.Alpha = 1;
            InitializeCorners(new Point(0,0));
        }
        public Polygon(Color fillColor)
        {
            Initialize();
            this.FillColor = fillColor;
            InitializeCorners(new Point(0,0));
        }
        public Polygon(Point startPos)
        {
            Initialize();
            InitializeCorners(startPos);
        }
        public Polygon(Point startPos,Color fillColor)
        {
            Initialize();
            this.FillColor = fillColor;
            InitializeCorners(startPos);
        }
        private void InitializeCorners(Point startsPos)
        {
            Corners = new Point[8];
            Corners[0] = new Point(startsPos.X, startsPos.Y);
            Corners[1] = new Point(startsPos.X+60, startsPos.Y);
            Corners[2] = new Point(startsPos.X+120, startsPos.Y);
            Corners[3] = new Point(startsPos.X+120, startsPos.Y+60);
            Corners[4] = new Point(startsPos.X+120, startsPos.Y+100);
            Corners[5] = new Point(startsPos.X+60, startsPos.Y+100);
            Corners[6] = new Point(startsPos.X, startsPos.Y+100);
            Corners[7] = new Point(startsPos.X, startsPos.Y+60);
        }
        private void Initialize()
        {
            this.SelectedCorner = -1;
            this.Type = Type.POLYGON;
            this.FillColor = Color.Black;
            this.Name = "Polygon";
        }
         
        public override string ToString()
        {
            //return base.ToString();
            return FillColor.ToString();
        }

    }
}
