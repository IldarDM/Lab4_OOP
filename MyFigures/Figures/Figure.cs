using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace MyFigures
{
    abstract public class Figure
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public int number;
        public string name;
        public static Bitmap bitmap;
        public static PictureBox pictureBox;
        public static Pen pen;
        public Figure() { }
        public Figure(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public Figure(string name, int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.name = name;
        }
        abstract public void Draw();
        public virtual void MoveTo(int x, int y)
        {
            try
            {
                if (!(x < 0 || y < 0 || x + width > pictureBox.Width || y + height > pictureBox.Height))
                {
                    this.x = x; this.y = y;
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
        public void ClearMap()
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.WhiteSmoke);
            pictureBox.Image = bitmap;
        }
        public void DeleteF(Figure figure, bool flag)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.FillRectangle(Brushes.White, x, y, width, height);
            FiguresContainer.figureList.Remove(figure);
            ClearMap();
            foreach (Figure f in FiguresContainer.figureList)
            {
                f.Draw();
            }
            if (flag != true)
            {
                FiguresContainer.figureList.Add(figure);
            }
            pictureBox.Image = bitmap;
        }
        public void DrawText(string type,int number)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString($"{type} {number}", new Font("Times New Roman", 10), Brushes.Gray, new RectangleF(x,y,width,height), sf);
        }
        public void DrawText(string type, int number, int x, int y, int width, int height)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString($"{type} {number}", new Font("Times New Roman", 10), Brushes.Gray, new RectangleF(x, y, width, height), sf);
        }
        public void DrawText(string name)
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            StringFormat sf = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            g.DrawString($"{name}", new Font("Times New Roman", 10), Brushes.Gray, new RectangleF(x, y, width, height), sf);
        }
    }

}
