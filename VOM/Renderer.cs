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
using System.Drawing.Drawing2D;

namespace VOM
{
    public class Renderer
    {
        public SmoothingMode SmoothingMode { get; set; }
        public bool RoundedPolygons { get; set; }
        public bool DrawCenterPoint { get; set; }
        public DrawMode DrawMode { get; set; }

        List<IRenderable> rObjects = new List<IRenderable>();
        public Renderer()
        {
        }
        public void Add(IRenderable obj)
        {
            rObjects.Add(obj);
        }
        public void Add(List<IRenderable> objs)
        {
            for (int i = 0; i < objs.Count; i++)
            {
                rObjects.Add(objs[i]);
            }
        }
        public void Remove(IRenderable obj)
        {
            rObjects.Remove(obj);
        }
        public void Render(Graphics g)
        {
        }
    }
}
