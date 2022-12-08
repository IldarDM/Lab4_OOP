using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFigures
{
    public class Polygon : Figure
    {
        public Point[] points;
        public static int count = 0;
        public int r_x;
        public int r_y;
        public Polygon() { }
        public Polygon(Point[] points) 
        {
            this.points = points;
            for (int i = 0; i < points.Length; i++)
            {
                if (x > points[i].X) { x = points[i].X; }
                if (x < 0) { throw new Exception("Фигура должна помещаться на холст"); }
                if (y > points[i].Y) { y = points[i].Y; }
                if (y < 0) { throw new Exception("Фигура должна помещаться на холст"); }
                if (r_x < points[i].X) { r_x = points[i].X; }
                if (r_x > pictureBox.Width) { throw new Exception("Фигура должна помещаться на холст"); }
                if (r_y < points[i].Y) { r_y = points[i].Y; }
                if (r_y > pictureBox.Height) { throw new Exception("Фигура должна помещаться на холст"); }
            }
            number = count;
            count++;
            FiguresContainer.PolygonsList.Add(this);
            FiguresContainer.figureList.Add(this);
        }
        public override void Draw()
        {
            try
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawPolygon(pen, points);
                pictureBox.Image = bitmap;
                DrawText("Pol", number, x, y, r_x - x, r_y - y);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
        public override void MoveTo(int dx, int dy)
        {
            try
            {
                for (int i = 0; i < points.Length; i++)
                {
                    if (points[i].X + dx < pictureBox.Width && points[i].X + dx > 0 &&
                        points[i].Y + dy < pictureBox.Height && points[i].Y + dy > 0)
                    {
                        points[i].X += dx; points[i].Y += dy;
                    }
                    else
                    {
                        throw new Exception("Фигура должна помещаться на холст");
                    }
                }
                this.x += dx; this.y += dy;
                this.r_x += dx; this.r_y += dy;
                DeleteF(this, false);
                Draw();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
    }
}
