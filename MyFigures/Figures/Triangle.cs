using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFigures
{
    public class Triangle : Polygon
    {
        public static new int count = 0;
        public Triangle() { }
        public Triangle(Point[] points)
        {
            if (points.Length != 3)
            {
                throw new Exception("Треугольник должен задаваться 3 точками");
            }
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
            FiguresContainer.TrianglesList.Add(this);
            FiguresContainer.figureList.Add(this);
            number = count;
            count++;
        }
        public Triangle(Point[] points, bool flag)
        {
            try
            {
                if (points.Length != 3)
                {
                    throw new Exception("Треугольник должен задаваться 3 точками");
                }
                this.points = points;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
        public override void Draw()
        {
            try
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawPolygon(pen, points);
                pictureBox.Image = bitmap;
                DrawText("Tri", number, x, y, r_x - x, r_y - y);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
        public void Draw(bool f)
        {
            try
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawPolygon(pen, points);
                pictureBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
    }
}

