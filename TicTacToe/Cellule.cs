using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Cellule
    {
        private Rectangle rec;
        private int etat;

        public Cellule(int tx, int ty, int w)
        {
            rec = new Rectangle(tx, ty, w, w);
            etat = 0;
        }
        public void reset()
        {
            this.etat = 0;
        }
       
        public bool PointInCell(Point p)
        {
            bool r = this.rec.Contains(p);
            return r;
        }

        public void dessiner(ref Graphics g)
        {
            Pen s = new Pen(Color.White, 8);
            g.DrawRectangle(s, rec);
        }
        public void rond(ref Graphics g)
        {
            if (etat == 0)
            {
                Pen stylo = new Pen(Color.Purple, 2);
                Brush s = new SolidBrush(Color.Purple);
                g.FillEllipse(s, rec);
                g.DrawEllipse(stylo, rec);
                etat = -1;
            }
        }
        public void Croix(ref Graphics g)
        {
            if (etat == 0)
            {
                Pen s = new Pen(Color.Purple, 2);
                g.DrawLine(s, rec.Left, rec.Top, rec.Right, rec.Bottom);
                g.DrawLine(s, rec.Left, rec.Bottom, rec.Right, rec.Top);
                etat = 1;
            }
        }

        public void DrawImage(ref Graphics g, Image image)
        {
            if (etat == 0)
            {
                Image newImage = image;
                Point centre_cell = new Point((rec.X + rec.Width / 2) - (newImage.Width / 2), (rec.Y + rec.Height / 2) - (newImage.Height / 2));
              
                g.DrawImage(newImage, centre_cell);
              
                etat = 1;
            }
          

        }
    }
}
