using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


static class Programm
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
            Application.Run(new Sierpinski());
    }
}
class Sierpinski : Form
{
    private int iteration = 1;

    public Sierpinski()
    {
        this.MinimumSize = new Size(600, 600);
        this.MaximumSize = new Size(600, 600);
        Text = "Sierpinski-Dreieck";	
    }




    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        Brush brush1 = new SolidBrush(Color.RoyalBlue);
        RectangleF bounds = e.Graphics.VisibleClipBounds;
        PointF[] points = { new PointF(bounds.X, bounds.Y + bounds.Height), new PointF(bounds.X + bounds.Width / 2, bounds.Y), new PointF(bounds.X + bounds.Width, bounds.Y + bounds.Height) };

        SierpinskiTriangle(e.Graphics, brush1, points, iteration);

        g.DrawString(iteration.ToString(), Font, Brushes.Black, 1, 1);
    }
    private void SierpinskiTriangle(Graphics g, Brush brush, PointF[] points, int iteration1)
    {
        if (iteration1 == 1)
        {
            g.FillPolygon(brush, points);
        }
        else
        {
            PointF[] hilfsPoints = { new PointF((Math.Max(points[0].X, points[1].X) - Math.Min(points[0].X, points[1].X)) / 2 + Math.Min(points[0].X, points[1].X), (Math.Max(points[0].Y, points[1].Y) - Math.Min(points[0].Y, points[1].Y)) / 2 + Math.Min(points[0].Y, points[1].Y)),
                                    new PointF((Math.Max(points[0].X, points[2].X) - Math.Min(points[0].X, points[2].X)) / 2 + Math.Min(points[0].X, points[2].X), (Math.Max(points[0].Y, points[2].Y) - Math.Min(points[0].Y, points[2].Y) )/ 2 + Math.Min(points[0].Y, points[2].Y)),
                                    new PointF((Math.Max(points[2].X, points[1].X) - Math.Min(points[2].X, points[1].X)) / 2 + Math.Min(points[2].X, points[1].X), (Math.Max(points[2].Y, points[1].Y) - Math.Min(points[2].Y, points[1].Y)) / 2 + Math.Min(points[2].Y, points[1].Y))};
            PointF[] points1 = { points[0], hilfsPoints[0], hilfsPoints[1] };
            PointF[] points2 = { hilfsPoints[0], points[1], hilfsPoints[2] };
            PointF[] points3 = { hilfsPoints[2], hilfsPoints[1], points[2] };

            SierpinskiTriangle(g, brush, points1, iteration1 - 1);
            SierpinskiTriangle(g, brush, points2, iteration1 - 1);
            SierpinskiTriangle(g, brush, points3, iteration1 - 1);
        }
    }




    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        if (e.KeyCode == Keys.Right)
        {
            iteration++;
            Refresh();
        }
        if (e.KeyCode == Keys.Left)
            if (iteration > 1)
            {
                iteration--;
                Refresh();
            }
    }


    
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    

}