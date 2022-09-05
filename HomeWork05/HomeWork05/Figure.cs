using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork05
{
    internal class Figure
    {
        public int n, l;
       
        public Figure(int n)
        {
            this.n = n;
            l = 1;
        }
        public Figure(int n, int l)
        {
            this.n = n;
            this.l = l;
        }

        public int Perimeter(int n, int l)
        {
            return n * l;
        }

        public double Area(int n, int l) 
        {
            return (l * l * n) / 4 * Math.Tan((180/n)*(Math.PI/180));
        }

        public double Corner (int n)
        {
        return 180 - 360 / n;
        }
        public void Drawing (Graphics g,int w,int h)
        {
            double r;
            double n1 = 0;//graduses
            r = Math.Sqrt((l / 2 * Math.Tan((180 / n) * (Math.PI / 180))) * (l / 2 * Math.Tan((180 / n) * (Math.PI / 180))) + ((l/2)*(l/2)));
            Pen p1 = new Pen(Color.Black, 2);
            while (n1 < 360)
            {
                g.DrawLine(p1, w / 2 + Convert.ToInt32(r * Math.Sin(n1 * (Math.PI / 180))), h / 2 - Convert.ToInt32(r * Math.Cos(n1 * Math.PI / 180)),
                               w / 2 + Convert.ToInt32(r * Math.Sin((n1 + (double)360 /n) * Math.PI / 180)), h / 2 - Convert.ToInt32(r * Math.Cos((n1 + (double)360 /n) * Math.PI / 180)));
                n1=n1+(double)360/n;
            }
        }
        
    }
}
