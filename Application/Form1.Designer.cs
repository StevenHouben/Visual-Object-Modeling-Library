using VOM;
namespace TestApplication
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            VOM.Settings settings2 = new VOM.Settings();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.container = new System.Windows.Forms.Panel();
            this.btnColor = new System.Windows.Forms.Button();
            this.propertyGridMain = new System.Windows.Forms.PropertyGrid();
            this.canvas1 = new VOM.Canvas();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1.SuspendLayout();
            this.container.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(958, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::TestApplication.Properties.Resources.pencil;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "DrawMode";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // container
            // 
            this.container.Controls.Add(this.propertyGrid1);
            this.container.Controls.Add(this.btnColor);
            this.container.Controls.Add(this.propertyGridMain);
            this.container.Dock = System.Windows.Forms.DockStyle.Right;
            this.container.Location = new System.Drawing.Point(656, 25);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(302, 467);
            this.container.TabIndex = 3;
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnColor.Location = new System.Drawing.Point(0, 283);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(302, 23);
            this.btnColor.TabIndex = 5;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // propertyGridMain
            // 
            this.propertyGridMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.propertyGridMain.Location = new System.Drawing.Point(0, 0);
            this.propertyGridMain.Name = "propertyGridMain";
            this.propertyGridMain.Size = new System.Drawing.Size(302, 283);
            this.propertyGridMain.TabIndex = 0;
            // 
            // canvas1
            // 
            this.canvas1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.canvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas1.Location = new System.Drawing.Point(0, 25);
            this.canvas1.Mode = VOM.Modes.NONE;
            this.canvas1.Name = "canvas1";
            this.canvas1.SelectedPolygon = null;
            this.canvas1.Settings = settings2;
            this.canvas1.Size = new System.Drawing.Size(656, 467);
            this.canvas1.TabIndex = 0;
            this.canvas1.Click += new System.EventHandler(this.canvas1_Click1);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 306);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(302, 161);
            this.propertyGrid1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 492);
            this.Controls.Add(this.canvas1);
            this.Controls.Add(this.container);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.container.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Button btnColor;
        private Canvas canvas1;
        private System.Windows.Forms.PropertyGrid propertyGridMain;
        private System.Windows.Forms.PropertyGrid propertyGrid1;




    }
}

