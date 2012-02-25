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
using System.Drawing.Drawing2D;
using System.Drawing;
using System.ComponentModel;

namespace VOM
{
    public class Settings
    {
        [CategoryAttribute("CanvasSettings")]
        public SmoothingMode SmoothingMode { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public bool RoundedPolygons { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public bool DrawCenterPoint { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public DrawMode DrawMode { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public int DragSquareSize { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public int DragSquareBorderSize { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public Color DragSquareFillColor { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public Color DragSquareBorderColor { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public Color DragSquareSelectionFillColor { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public Color DefaultColor { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public int DragCircleSize { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public int DragCircleBorderSize { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public Color DragCircleFillColor { get; set; }
        [CategoryAttribute("CanvasSettings")]
        public Color DragCircleBorderColor { get; set; }
        public Settings()
        {
            this.DragSquareBorderColor = Color.Black;
            this.DragSquareFillColor = Color.White;
            this.DragSquareSelectionFillColor = Color.Red;
            this.DragSquareBorderSize = 2;
            this.DragSquareSize = 10;

            this.DragCircleBorderColor = Color.Black;
            this.DragCircleFillColor = Color.White;
            this.DragCircleSize = 10;
            this.DragCircleBorderSize = 2;
            this.DefaultColor = Color.Blue;

            this.RoundedPolygons = false;
            this.SmoothingMode = SmoothingMode.AntiAlias;
            this.DrawMode = DrawMode.POLYGON;
        }
    }
}
