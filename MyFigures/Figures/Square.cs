using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFigures
{
    public class Square : Rectangle
    {
        public static new int count = 0;
        public Square(int x, int y, int width)
        {
            this.x = x;
            this.y = y; 
            this.width = width;
            if (!(x < 0 || y < 0 || x + width > pictureBox.Width || y + height > pictureBox.Height))
            {
                FiguresContainer.SquaresList.Add(this);
                FiguresContainer.figureList.Add(this);
                number = count;
                count++;
            }
            else
            {
                throw new Exception("Фигура должна помещаться на холст");
            }
        }
        public override void Draw()
        {
            try
            {
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawRectangle(pen, x, y, width, width);
                pictureBox.Image = bitmap;
                DrawText("Sq", number);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }

        public override void MoveTo(int x, int y)
        {
            height = width;
            base.MoveTo(x, y);
        }

        public void ResizeSquare(int width)
        {
            try
            {
                if (!(x < 0 || y < 0 || x + width > pictureBox.Width || y + width > pictureBox.Height))
                {
                    this.width = width;
                    DeleteF(this, false);
                    Draw();
                }
                else
                {
                    throw new Exception("Фигура должна помещаться на холст");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ашипка");
            }
        }
    }
}
