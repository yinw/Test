using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Point[] ps = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (ps != null)
            {
                
                Graphics g = e.Graphics;
                g.DrawLine(Pens.Black, ps[0], ps[1]);
                g.DrawLine(Pens.Black, ps[1], ps[2]);
                g.DrawLine(Pens.Black, ps[2], ps[3]);
                g.DrawLine(Pens.Black, ps[3], ps[0]);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ps = new Point[4];
            ps[0] = new Point(e.X, e.Y);
            ps[1] = new Point(e.X + 45, e.Y);
            ps[2] = new Point(e.X + 45, e.Y + 25);
            ps[3] = new Point(e.X, e.Y + 25);
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ps != null)
            {
                ps[0] = Transformations.Transformations_2D.Affine(ps[0], 5, 2.5, 1.5, 4.2, 3.2, 2.2);
                ps[1] = Transformations.Transformations_2D.Affine(ps[1], 4.0, 3.3, 2.2, 2.1, 1.7, 1.8);
                ps[2] = Transformations.Transformations_2D.Affine(ps[2], 7.6, 1.5, 4.3, 2.4, 7.7, 8.8);
                ps[3] = Transformations.Transformations_2D.Affine(ps[3], 8.3, 4.7, 6.5, 6.7, 1.8, 2.0);
                this.Refresh();
            }
        }
    }
}
