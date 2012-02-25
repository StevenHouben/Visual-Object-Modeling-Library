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
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace VOM
{
    [ToolboxItem(true)]
    public class Canvas : Panel
    {
        #region Declarations
        private Modes mode;
        private List<Polygon> polyList = new List<Polygon>();
        private bool newNodeCreated = false;
        private bool mouseClicked = false;
        private int selectedIndex = -1;
        private DrawRectangle drawRect;
        private Polygon drawPolygon;
        #endregion

        #region Constructor
        public Canvas()
        {
            InitializeCanvas();
            InitializeEvents();
        }
        #endregion

        #region Properties
        public Settings Settings { get; set; }
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Polygon SelectedPolygon
        {
            get
            {
                if (selectedIndex > -1)
                    return polyList[selectedIndex];
                else return null;
            }
            set
            {
                if (selectedIndex > 0)
                    polyList[selectedIndex] = value;
            }
        }
        public Modes Mode
        {
            get { return this.mode; }
            set
            {
                this.mode = value;
                UpdateCursor(mode);
            }

        }
        #endregion

        #region Events
        private void Canvas_DoubleClick(Object sender, EventArgs e)
        {
            if(selectedIndex >-1)
            if (polyList[selectedIndex] != null)
                ChangeZIndex(polyList[selectedIndex]);
        }
        private void Canvas_Paint(Object sender, PaintEventArgs e)
        {
            RenderPolygons(e.Graphics);
        }
        private void Canvas_MouseMove(Object sender, MouseEventArgs e)
        {
            if (Mode == Modes.SHAPEMODE)
                if (e.Button == MouseButtons.Right)
                {
                    if (!newNodeCreated)
                    {
                        AddCornerToList(polyList[selectedIndex].Corners[polyList[selectedIndex].SelectedCorner], polyList[selectedIndex].Corners[polyList[selectedIndex].SelectedCorner]);
                        newNodeCreated = true;
                    }
                    polyList[selectedIndex].Corners[polyList[selectedIndex].SelectedCorner + 1] = new Point(e.X, e.Y);
                }
                else if (e.Button == MouseButtons.Left)
                    polyList[selectedIndex].Corners[polyList[selectedIndex].SelectedCorner] = new Point(e.X, e.Y);
            if (Mode == Modes.DRAGMODE)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point oldDragPoint = polyList[selectedIndex].DragPoint;
                    polyList[selectedIndex].DragPoint = new Point(e.X, e.Y);
                    for (int i = 0; i < polyList[selectedIndex].Corners.Length; i++)
                    {
                        polyList[selectedIndex].Corners[i].X += (polyList[selectedIndex].DragPoint.X - oldDragPoint.X);
                        polyList[selectedIndex].Corners[i].Y += (polyList[selectedIndex].DragPoint.Y - oldDragPoint.Y);
                    }
                }
                else if (e.Button == MouseButtons.Middle)
                {
                    Remove(polyList[selectedIndex]);
                }
            }
            if (Mode == Modes.DRAWMODE && drawRect != null)
            {
                drawRect.EndPoint = e.Location;
                drawPolygon = new Polygon(drawRect.StartPoint, Settings.DefaultColor);
                Point[] corners = new Point[4];
                corners[0] = drawRect.StartPoint;
                corners[1] = new Point(drawRect.StartPoint.X, drawRect.EndPoint.Y);
                corners[2] = drawRect.EndPoint;
                corners[3] = new Point(drawRect.EndPoint.X, drawRect.StartPoint.Y);
                drawPolygon.Corners = corners;
            }
            if (Mode != Modes.DRAWMODE)
            {
                if (GetPolygonFromPoint(e.Location) != null)
                {
                    this.Cursor = Cursors.SizeAll;

                }
                else this.Cursor = Cursors.Arrow;
            }

            this.Invalidate();
        }
        private void Canvas_MouseUp(Object sender, MouseEventArgs e)
        {
            if (Mode == Modes.DRAWMODE && drawRect != null)
            {
                drawRect.EndPoint = e.Location;
                Polygon poly = new Polygon(drawRect.StartPoint, Settings.DefaultColor);
                Point[] corners = new Point[4];
                corners[0] = drawRect.StartPoint;
                corners[1] = new Point(drawRect.StartPoint.X, drawRect.EndPoint.Y);
                corners[2] = drawRect.EndPoint;
                corners[3] = new Point(drawRect.EndPoint.X, drawRect.StartPoint.Y);
                poly.Corners = corners;
                polyList.Add(poly);
            }
            Mode = Modes.NONE;
            mouseClicked = false;
            newNodeCreated = false;
            if (selectedIndex != -1)
                polyList[selectedIndex].SelectedCorner = -1;

            this.Invalidate();
        }
        private void Canvas_MouseDown(Object sender, MouseEventArgs e)
        {
            if (Mode != Modes.DRAWMODE)
            {
                if (selectedIndex == -1)
                {
                    selectedIndex = GetPolygonIndexFromPoint(e.Location);
                }
                if (selectedIndex != -1)
                {
                    polyList[selectedIndex].SelectedCorner = CalculateDragPoint(polyList[selectedIndex].Corners, e);
                    if (e.Button == MouseButtons.Middle && selectedIndex > -1 && polyList[selectedIndex].SelectedCorner > -1)
                    {
                        RemoveCornerFromList(polyList[selectedIndex].Corners[polyList[selectedIndex].SelectedCorner]);
                        polyList[selectedIndex].SelectedCorner = CalculateDragPoint(polyList[selectedIndex].Corners, e);
                    }
                    if (polyList[selectedIndex].SelectedCorner > -1)
                    {
                        Mode = Modes.SHAPEMODE;
                    }
                    else if (polyList[selectedIndex].SelectedCorner == -1)
                    {
                        selectedIndex = GetPolygonIndexFromPoint(e.Location);
                        if (selectedIndex > -1)
                        {
                            polyList[selectedIndex].DragPoint = e.Location;
                            Mode = Modes.DRAGMODE;
                        }
                    }
                }
            }
            else{
                selectedIndex = -1;
                drawRect = new DrawRectangle();
                drawRect.StartPoint = e.Location;
                drawRect.EndPoint = e.Location;
                mouseClicked = true;
            }
            this.Invalidate();
        }
        #endregion

        #region Private Functions
        private void InitializeCanvas()
        {
            this.DoubleBuffered = true;
            this.Settings = new Settings();
        }
        private void InitializeEvents()
        {
            this.Paint += new PaintEventHandler(Canvas_Paint);
            this.MouseDown += new MouseEventHandler(Canvas_MouseDown);
            this.MouseUp += new MouseEventHandler(Canvas_MouseUp);
            this.MouseMove += new MouseEventHandler(Canvas_MouseMove);
            this.DoubleClick += new EventHandler(Canvas_DoubleClick);
        }
        private void RenderPolygons(Graphics g)
        {
            g.SmoothingMode = Settings.SmoothingMode;
            foreach (Polygon poly in polyList)
            {
                Point centerPoint = CalculateCenterPoint(poly.Corners);

                if (poly.Type == Type.POLYGON)
                {
                    if (Settings.RoundedPolygons)
                        g.FillClosedCurve(new SolidBrush(Color.FromArgb(poly.Alpha,poly.FillColor.R,poly.FillColor.G,poly.FillColor.B)), poly.Corners);
                    else
                        g.FillPolygon(new SolidBrush(poly.FillColor), poly.Corners);
                }
                else
                {
                    Range rX = MinMaxRangeFromPolygon(poly,true);
                    Range rY = MinMaxRangeFromPolygon(poly,false);
                    g.FillEllipse(new SolidBrush(poly.FillColor),new Rectangle(new Point(rX.Min,rY.Min),new Size(rX.Difference,rY.Difference)));
                }

                if (selectedIndex > -1)
                {
                    if (poly == polyList[selectedIndex])
                    {
                        for (int i = 0; i < poly.Corners.Length; i++)
                        {
                            Point p = poly.Corners[i];
                            Color fillColor;
                            if (poly.SelectedCorner > -1 && p == poly.Corners[poly.SelectedCorner])
                                fillColor = Settings.DragSquareSelectionFillColor;
                            else
                                fillColor = Settings.DragSquareFillColor;
                            Rectangle dragSpotSize = PointToRectangle(p, Settings.DragSquareSize);
                            Rectangle dragSpotBorder = PointToRectangle(p, Settings.DragSquareSize);
                            g.FillRectangle(new SolidBrush(fillColor), dragSpotSize);
                            g.DrawRectangle(new Pen(new SolidBrush(Settings.DragSquareBorderColor), Settings.DragSquareBorderSize), dragSpotBorder);
                        }
                        if (Settings.DrawCenterPoint)
                        {
                            g.FillEllipse(new SolidBrush(Settings.DragCircleFillColor), PointToRectangle(centerPoint, Settings.DragCircleSize));
                            g.DrawEllipse(new Pen(new SolidBrush(Settings.DragCircleBorderColor), Settings.DragSquareBorderSize), PointToRectangle(centerPoint, Settings.DragCircleSize));
                        }
                    }
                }
            }
            if (Mode == Modes.DRAWMODE && drawRect != null && mouseClicked && drawPolygon !=null)
            {
                if (Settings.DrawMode == DrawMode.POLYGON)
                    DrawSelectionPolygon(g);
                else if (Settings.DrawMode == DrawMode.SELECTIONRECTANGLE)
                    DrawSelectionRectangle(g);
                else{
                    DrawSelectionPolygon(g);
                    DrawSelectionRectangle(g);
                }

            }
        }
        private void DrawSelectionPolygon(Graphics g)
        {
            g.FillClosedCurve(new SolidBrush(drawPolygon.FillColor), drawPolygon.Corners);
        }
        private void DrawSelectionRectangle(Graphics g)
        {
            Pen pen = new Pen(new SolidBrush(Color.Black), 1);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            if (drawRect.Size.Width > 0 && drawRect.Size.Height > 0)
                g.DrawRectangle(pen, new Rectangle(drawRect.StartPoint, drawRect.Size));
            else if (drawRect.Size.Width > 0 && drawRect.Size.Height < 0)
            {
                drawRect.Size = new Size(drawRect.Size.Width, drawRect.Size.Height * -1);
                g.DrawRectangle(pen, new Rectangle(new Point(drawRect.StartPoint.X, drawRect.EndPoint.Y), drawRect.Size));
            }
            else if (drawRect.Size.Width < 0 && drawRect.Size.Height > 0)
            {
                drawRect.Size = new Size(drawRect.Size.Width * -1, drawRect.Size.Height);
                g.DrawRectangle(pen, new Rectangle(new Point(drawRect.EndPoint.X, drawRect.StartPoint.Y), drawRect.Size));
            }
            else if (drawRect.Size.Width < 0 && drawRect.Size.Height < 0)
            {
                drawRect.Size = new Size(drawRect.Size.Width * -1, drawRect.Size.Height * -1);
                g.DrawRectangle(pen, new Rectangle(drawRect.EndPoint, drawRect.Size));
            }
        }
        private void AddCornerToList(Point newPoint, Point derived)
        {
            int index = FindCornerIndexFromPoint(derived);
            if (index >= 0)
            {
                Point[] corners = new Point[polyList[selectedIndex].Corners.Length + 1];
                for (int i = 0; i <= index; i++)
                    corners[i] = polyList[selectedIndex].Corners[i];
                corners[index + 1] = newPoint;
                for (int i = index + 2; i <= polyList[selectedIndex].Corners.Length; i++)
                    corners[i] = polyList[selectedIndex].Corners[i - 1];
                polyList[selectedIndex].Corners = corners;
                this.Invalidate();
            }
        }
        private void RemoveCornerFromList(Point deletedPoint)
        {
            int index = FindCornerIndexFromPoint(deletedPoint);
            if (index >= 0)
            {
                Point[] corners = new Point[polyList[selectedIndex].Corners.Length - 1];
                for (int i = 0; i < index; i++)
                    corners[i] = polyList[selectedIndex].Corners[i];
                for (int i = index; i < corners.Length; i++)
                    corners[i] = polyList[selectedIndex].Corners[i + 1];
                polyList[selectedIndex].Corners = corners;
               
                this.Invalidate();
            }
        }
        private void UpdateCursor(Modes m)
        {
            switch (m)
            {
                case Modes.DRAWMODE:
                    this.Cursor = Cursors.Cross;
                    break;
                default:
                    this.Cursor = Cursors.Arrow;
                    break;
            }
        }
        private void ChangeZIndex(Polygon selected)
        {
            polyList.Remove(selected);
            polyList.Add(selected);
            this.Invalidate();
        }
        private int CalculateDragPoint(Point[] corners, MouseEventArgs e)
        {
            for (int i = 0; i < corners.Length; i++)
                if (PointToRectangle(corners[i], Settings.DragSquareSize).IntersectsWith(new Rectangle(e.X, e.Y, 1, 1))) return i;
            if (PointToRectangle(polyList[selectedIndex].DragPoint, Settings.DragSquareSize).IntersectsWith(new Rectangle(e.X, e.Y, 1, 1))) return -2;
            return -1;
        }
        private int GetPolygonIndexFromPoint(Point click)
        {
            for (int i = polyList.Count - 1; i >= 0; i--)
            {
                Range rangeX = MinMaxRangeFromPolygon(polyList[i], true);
                Range rangeY = MinMaxRangeFromPolygon(polyList[i], false);
                if (click.X < rangeX.Max && click.X > rangeX.Min &&
                    click.Y < rangeY.Max && click.Y > rangeY.Min)
                    return i;
            }
            return -1;
        }
        private Point CalculateCenterPoint(Point[] corners)
        {
            int bigX = 0;
            int smallX = corners[0].X;
            int bigY = 0;
            int smallY = corners[0].Y;
            for (int i = 0; i < corners.Length; i++)
            {
                if (corners[i].X < smallX)
                    smallX = corners[i].X;
                if (corners[i].X > bigX)
                    bigX = corners[i].X;
                if (corners[i].Y < smallY)
                    smallY = corners[i].Y;
                if (corners[i].Y > bigY)
                    bigY = corners[i].Y;
            }
            return new Point((smallX + bigX) / 2, (smallY + bigY) / 2);
        }
        private int FindCornerIndexFromPoint(Point pF)
        {
            for (int i = 0; i < polyList[selectedIndex].Corners.Length; i++)
            {
                if (pF == polyList[selectedIndex].Corners[i]) return i;
            }
            return -1;
        }
        private int FindIndexFromPolygon(Polygon poly)
        {
            for (int i = 0; i < polyList.Count; i++)
            {
                if (polyList[i] == poly) return i;
            }
            return -1;
        }
        private Point RectangleToPoint(Rectangle r)
        {
            return new Point(((r.X + (r.X + r.Width)) / 2), ((r.Y + (r.Y + r.Height)) / 2));
        }
        private Range MinMaxRangeFromPolygon(Polygon poly, bool X)
        {
            Range range = new Range(Math.Max(ClientRectangle.Width, ClientRectangle.Height), -1);
            if (X)
            {
                foreach (Point p in poly.Corners)
                {
                    if (p.X > range.Max) range.Max = p.X;
                    if (p.X < range.Min) range.Min = p.X;
                }
            }
            else
            {
                foreach (Point p in poly.Corners)
                {
                    if (p.Y > range.Max) range.Max = p.Y;
                    if (p.Y < range.Min) range.Min = p.Y;
                }
            }
            return range;
        }
        private Rectangle PointToRectangle(Point p, int size)
        {
            return new Rectangle(p.X - size / 2, p.Y - size / 2, size, size);
        }
        private Polygon GetPolygonFromPoint(Point click)
        {
            for (int i = polyList.Count - 1; i >= 0; i--)
            {
                Range rangeX = MinMaxRangeFromPolygon(polyList[i], true);
                Range rangeY = MinMaxRangeFromPolygon(polyList[i], false);
                if (click.X < rangeX.Max && click.X > rangeX.Min &&
                    click.Y < rangeY.Max && click.Y > rangeY.Min)
                    return polyList[i];
            }
            return null;
        }
        #endregion

        #region Public Functions
        public void Add(Polygon p)
        {
            polyList.Add(p);
        }
        public void Remove(Polygon p)
        {
            polyList.Remove(p);
            selectedIndex = -1;
        }
        #endregion
    }
}
