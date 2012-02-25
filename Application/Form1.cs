using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VOM;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        private Color SelectedColor;
        public Form1()
        {
            InitializeComponent();
			this.BackColor = Color.White;
            
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            canvas1.Mode = Modes.DRAWMODE;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            canvas1.Mode = Modes.DRAGMODE;
        }

        private void canvas1_Click1(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = canvas1.SelectedPolygon;
            if (canvas1.SelectedPolygon != null)
            {
                SelectedColor = canvas1.SelectedPolygon.FillColor;
                btnColor.BackColor = SelectedColor;
            }
            else
            {
                SelectedColor = canvas1.Settings.DefaultColor;
                btnColor.BackColor = SelectedColor;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            DialogResult d = cd.ShowDialog();
            if (d == DialogResult.OK)
            {
                btnColor.BackColor = cd.Color;
                canvas1.Settings.DefaultColor = cd.Color;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnColor.BackColor = canvas1.Settings.DefaultColor;
            propertyGridMain.SelectedObject = canvas1.Settings;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
        }

        private void canvas1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
            if (e.KeyCode == Keys.Delete)
            {
                if (canvas1.SelectedPolygon != null)
                {
                    canvas1.Remove(canvas1.SelectedPolygon);
                }
            }
        }
    }
}
