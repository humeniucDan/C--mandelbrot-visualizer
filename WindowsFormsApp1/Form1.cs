using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Drawing.Graphics g = this.CreateGraphics();
            System.Drawing.SolidBrush b = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 0, 0, 200));
            g.FillRectangle(b, 200, 200, 1, 1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double iter, maxIter = 10000, m = 0, cx, cy, zx, zy, a1, a2, windowSize = 1000, bv;
            System.Drawing.Graphics g = this.CreateGraphics();
            System.Drawing.SolidBrush b = new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 0, 0, 200));
            for (int j = 0; j <= windowSize - 1; j++)
            {
                for (int i = 0; i <= windowSize - 1; i++)
                {
                    zx = cx = i / windowSize * 3 - 2f;
                    zy = cy = j / windowSize * 3 - 1.1f;
                    iter = 1;
                    while (iter < maxIter && zx * zx + zy * zy <= 4)
                    {
                        a1 = zx * zx - zy * zy;
                        a2 = 2 * zx * zy;
                        zx = a1 + cx;
                        zy = a2 + cy;
                        iter++;
                    }
                    if (iter == maxIter) b.Color = Color.Black;
                    else
                    {
                        bv = Math.Log(iter / maxIter * 5000, 5000) * 255;
                        if (bv < 0) b.Color = Color.Black;
                        else b.Color = Color.FromArgb(255, 0, 0, Convert.ToInt32(bv));
                    }
                    g.FillRectangle(b, new Rectangle(i, j, 1, 1));
                }
            }
            //button1.Text = Convert.ToString(m);
        }
    }
}
