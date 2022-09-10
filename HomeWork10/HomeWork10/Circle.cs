using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork10
{
    internal class Circle
    {
        public int x, y;
        public int diametr;
        int colorID;
        public Circle(int x, int y, int diametr, int colorID)
        {
            this.x = x;
            this.y = y;
            this.diametr = diametr;
            this.colorID = colorID;
        }

        public Circle()
        {
            this.x = 0;
            this.y = 0;
        }

        public void Move (int dx, int dy)
        {
            x = x + dx;
            y = y + dy;
        }

        public void Draw (Graphics g)
        {
            Pen pen = new Pen(Color.White, 2);
            if (colorID == 0)
            {
                pen = new Pen(Color.Blue, 2);
            }
            if (colorID == 1)
            {
                pen = new Pen(Color.Green, 2);
            }
            if (colorID == 2)
            {
                pen = new Pen(Color.Red, 2);
            }
            if (colorID == 3)
            {
                pen = new Pen(Color.Purple, 2);
            }
            if (colorID == 4)
            {
                pen = new Pen(Color.Orchid, 2);
            }
            g.DrawEllipse(pen, x, y, diametr, diametr);
        }
    }
}
