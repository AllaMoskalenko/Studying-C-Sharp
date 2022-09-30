using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace HomeWork16
{
    public abstract class Figure
    {
        protected Point point;
        public abstract Point pt { get; set; }

        public virtual Color color { get; set; }
        public void Draw() { }
        public abstract void Draw(Graphics g);
        public abstract string FigInfo();
        public abstract bool PointInObj (Point p);
        public virtual bool is_selected { get; set; }
    }

    public class Circle : Figure
    {
        public int radius;

        public override Point pt { get { return point; } set { point = value; } }
        public Circle(Point p, Color col, int r)
        {
            this.point.X = p.X;
            this.point.Y = p.Y;
            this.color = col;
            this.radius = r;
            is_selected = false;
        }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(color), point.X-radius/2, point.Y-radius/2, radius, radius);
            if (is_selected)
            {
                g.DrawEllipse(new Pen(Color.RoyalBlue, 4), point.X - radius / 2, point.Y - radius / 2, radius, radius);
            }
        }
        public override bool PointInObj(Point p)
        {
            
            if (Math.Sqrt(Math.Pow(point.X - p.X, 2) + Math.Pow(point.Y - p.Y, 2)) < radius/2) return true;
            else return false;
        }
        public override string ToString()
        {
            return "circle";
        }
        public override string FigInfo()
        {
            return "C " + point.X + " " + point.Y + " " + color.R + " " + color.G + " " + color.B + " " + radius;
        }
    }

    public class Rectangle : Figure
    {
        public int width;
        public int height;
        public override Point pt { get { return point; } set { point = value; } }
        public Rectangle (Point p, Color col, int width, int height)
        {
            this.point.X = p.X;
            this.point.Y = p.Y;
            this.color = col;
            this.width = width;
            this.height = height;
        }
        public override void Draw (Graphics g)
        {            
            g.FillRectangle(new SolidBrush(color), point.X - width / 2, point.Y - height /2, width, height);
            if (is_selected)
            {
                g.DrawRectangle(new Pen(Color.RoyalBlue, 4), point.X - width / 2, point.Y - height / 2, width, height);
            }
        }
        public override bool PointInObj(Point p)
        {
            
            if (p.X - point.X + width / 2 < width && p.Y - point.Y + height / 2 < height && point.X - width / 2 < p.X && point.Y - height / 2 < p.Y) return true;
            else return false;
        }
        public override string ToString()
        {
            return "rectangle";
        }
        public override string FigInfo()
        {
            return "R " + point.X + " " + point.Y + " " + color.R + " " + color.G + " " + color.B + " " + width + " " + height;
        }
    }

    public class Polygon : Figure
    {
        public int radius
        {
            get { return R; }
            set
            {
                R = value;
                points = new Point[V];      //massiv vershin
                int corner = 0;
                for (int i = 0; i < V; i++)
                {
                    points[i].X = (int)(R * Math.Cos(corner * (Math.PI / 180))) + point.X;
                    points[i].Y = (int)(R * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    corner += 360 / V;
                }
            }
        }
        public int tops
        {
            get { return V; }
            set
            {
                V = value;
                points = new Point[V];      
                int corner = 0;
                for (int i = 0; i < V; i++)
                {
                    points[i].X = (int)(R * Math.Cos(corner * (Math.PI / 180))) + point.X;
                    points[i].Y = (int)(R * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    corner += 360 / V;
                }
            }
        }
        public override Point pt
        {
            get { return point; }
            set 
            { 
                point = value;
                int corner = 0;
                for (int i = 0; i < V; i++)
                {
                    points[i].X = (int)(R * Math.Cos(corner * (Math.PI / 180))) + point.X;
                    points[i].Y = (int)(R * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    corner += 360 / V;
                }
            }
        }
        
        Point[] points;
        
        int V, R;
        public Polygon (Point p, Color col, int num, int l)
        {
            this.point.X = p.X;
            this.point.Y = p.Y;
            this.color = col;
            this.tops = num;
            this.radius = l;            
        }
        public override void Draw(Graphics g)
        {
            g.FillPolygon(new SolidBrush(color), points);
            if (is_selected)
            {
                g.DrawPolygon(new Pen(Color.RoyalBlue, 4), points);
            }
        }
        public override bool PointInObj(Point p)
        {
            Point temp1 = new Point();
            Point temp2 = new Point();
            int count = 0;
            for (int i = 0; i < points.Length - 1; i++)
            {
                temp1.X = points[i].X;
                temp1.Y = points[i].Y;
                temp2.X = points[i + 1].X;
                temp2.Y = points[i + 1].Y;
                if ((((temp1.Y <= p.Y) && (p.Y < temp2.Y)) || ((temp2.Y <= p.Y) && (p.Y < temp1.Y))) && ((temp2.Y - temp1.Y) != 0)
                    && (p.X > ((temp2.X - temp1.X) * (p.Y - temp1.Y) / (temp2.Y - temp1.Y) + temp1.X))) count++;
            }
            temp1.X = points[0].X;
            temp1.Y = points[0].Y;
            temp2.X = points[points.Length - 1].X;
            temp2.Y = points[points.Length - 1].Y;
            if ((((temp1.Y <= p.Y) && (p.Y < temp2.Y)) || ((temp2.Y <= p.Y) && (p.Y < temp1.Y))) && ((temp2.Y - temp1.Y) != 0)
                    && (p.X > ((temp2.X - temp1.X) * (p.Y - temp1.Y) / (temp2.Y - temp1.Y) + temp1.X))) count++;
            if (count%2 == 1) return true; 
            else return false;
        }
        public override string ToString()
        {
            return "polygon";
        }
        public override string FigInfo()
        {
            return "P " + point.X + " " + point.Y + " " + color.R + " " + color.G + " " + color.B + " " + tops + " " + radius;
        }
    }

    public class Star : Figure
    {
        public int radius1 
        {
            get { return R1; }
            set
            {
                R1 = value;
                float corner = 0;
                for (int i = 0; i < points.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        points[i].X = (float)(R1 * Math.Cos(corner * (Math.PI / 180))) + point.X;
                        points[i].Y = (float)(R1 * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    }
                    else if (i % 2 != 0)
                    {
                        points[i].X = (float)(R2 * Math.Cos(corner * (Math.PI / 180))) + point.X;
                        points[i].Y = (float)(R2 * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    }
                    corner += 360.0f / (V * 2.0f);
                }
            }
        }
        public int radius2
        {
            get { return R2; }
            set
            {
                R2 = value;
                float corner = 0;
                for (int i = 0; i < points.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        points[i].X = (float)(R1 * Math.Cos(corner * (Math.PI / 180))) + point.X;
                        points[i].Y = (float)(R1 * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    }
                    else if (i % 2 != 0)
                    {
                        points[i].X = (float)(R2 * Math.Cos(corner * (Math.PI / 180))) + point.X;
                        points[i].Y = (float)(R2 * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    }
                    corner += 360.0f / (V * 2.0f);
                }
            }
        }
        public int tops
        {
            get { return V; }
            set
            {
                V = value;
                points = new PointF[V * 2];
                float corner = 0;
                for (int i = 0; i < points.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        points[i].X = (float)(R1 * Math.Cos(corner * (Math.PI / 180))) + point.X;
                        points[i].Y = (float)(R1 * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    }
                    else if (i % 2 != 0)
                    {
                        points[i].X = (float)(R2 * Math.Cos(corner * (Math.PI / 180))) + point.X;
                        points[i].Y = (float)(R2 * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    }
                    corner += 360.0f / (V * 2.0f);
                }
            }
        }
        public override Point pt                             //center point of figure (svoistvo)
        {
            get { return point; }
            set
            {
                point = value;
                float corner = 0;
                for (int i = 0; i < points.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        points[i].X = (float)(R1 * Math.Cos(corner * (Math.PI / 180))) + point.X;
                        points[i].Y = (float)(R1 * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    }
                    else if (i % 2 != 0)
                    {
                        points[i].X = (float)(R2 * Math.Cos(corner * (Math.PI / 180))) + point.X;
                        points[i].Y = (float)(R2 * Math.Sin(corner * (Math.PI / 180))) + point.Y;
                    }
                    corner += 360.0f / (V * 2.0f);
                }
            }
        }
        
        PointF[] points;

        int V, R1, R2;
        public Star (Point p, Color col, int num, int r1, int r2)
        {
            points = new PointF[num*2];
            this.point.X = p.X;
            this.point.Y = p.Y;
            this.color = col;
            this.tops = num;
            this.radius1 = r1;
            this.radius2 = r2;
        }
        public override void Draw(Graphics g)
        {
            g.FillPolygon(new SolidBrush(color), points);
            if (is_selected)
            {
                g.DrawPolygon(new Pen(Color.RoyalBlue, 4), points); 
            }
        }
        public override bool PointInObj(Point p)
        {
            PointF temp1 = new PointF();
            PointF temp2 = new PointF();
            int count = 0;
            for (int i = 0; i < points.Length - 1; i++)
            {
                temp1.X = points[i].X;
                temp1.Y = points[i].Y;
                temp2.X = points[i + 1].X;
                temp2.Y = points[i + 1].Y;
                if ((((temp1.Y <= p.Y) && (p.Y < temp2.Y)) || ((temp2.Y <= p.Y) && (p.Y < temp1.Y))) && ((temp2.Y - temp1.Y) != 0)
                    && (p.X > ((temp2.X - temp1.X) * (p.Y - temp1.Y) / (temp2.Y - temp1.Y) + temp1.X))) count++;
            }
            temp1.X = points[0].X;
            temp1.Y = points[0].Y;
            temp2.X = points[points.Length - 1].X;
            temp2.Y = points[points.Length - 1].Y;
            if ((((temp1.Y <= p.Y) && (p.Y < temp2.Y)) || ((temp2.Y <= p.Y) && (p.Y < temp1.Y))) && ((temp2.Y - temp1.Y) != 0)
                    && (p.X > ((temp2.X - temp1.X) * (p.Y - temp1.Y) / (temp2.Y - temp1.Y) + temp1.X))) count++;
            if (count % 2 == 1) return true;
            else return false;                     
        }
        public override string ToString()
        {
            return "star";
        }
        public override string FigInfo()
        {
            return "S " + point.X + " " + point.Y + " " + color.R + " " + color.G + " " + color.B + " " + tops + " " + radius1 + " " + radius2;
        }
    }


    public class Agregation : Figure
    {
        public List <Figure> groupFig;
        private Color CoLoR;
        public override Color color
        {
            get { return CoLoR; }
            set
            {
                CoLoR = value;
                for (int i = 0; i < groupFig.Count; i++)
                {
                    groupFig[i].color = CoLoR;
                }
            }
        }
        private bool SeLeCtEd=false;
        public override bool is_selected
        {
            get
            {
                return SeLeCtEd;
            }
            set 
            {
                SeLeCtEd = value;
                for (int i = 0; i < groupFig.Count; i++) 
                {
                    groupFig[i].is_selected = value;
                }

            }
        }
        public Agregation (List<Figure> groupfig, Point p)
        {
            groupFig = new List<Figure>();
            for (int i = 0; i < groupfig.Count; i++)
            {
                //   groupFig.Add(groupfig[i]);
                if (groupfig[i].ToString() == "circle")     { groupFig.Add(new Circle(groupfig[i].pt, groupfig[i].color, ((Circle)groupfig[i]).radius)); }
                if (groupfig[i].ToString() == "rectangle")  { groupFig.Add(new Rectangle(groupfig[i].pt, groupfig[i].color, ((Rectangle)groupfig[i]).width, ((Rectangle)groupfig[i]).height)); }
                if (groupfig[i].ToString() == "star")       { groupFig.Add(new Star(groupfig[i].pt, groupfig[i].color, ((Star)groupfig[i]).tops, ((Star)groupfig[i]).radius1, ((Star)groupfig[i]).radius2)); }
                if (groupfig[i].ToString() == "polygon")    { groupFig.Add(new Polygon(groupfig[i].pt, groupfig[i].color, ((Polygon)groupfig[i]).tops, ((Polygon)groupfig[i]).radius)); }
                if (groupfig[i].ToString() == "agregation") { groupFig.Add(new Agregation(((Agregation)groupfig[i]).groupFig, groupfig[i].pt)); }
            }
                this.point = new Point (p.X, p.Y);
        }
        public override Point pt 
        { 
            get 
            { 
                return point; 
            }
            set
            {
                int dx, dy;
                dx = value.X - this.point.X;
                dy = value.Y - this.point.Y;
                point = value;
                for (int i = 0; i<groupFig.Count; i++)
                {
                    groupFig[i].pt = new Point(groupFig[i].pt.X + dx, groupFig[i].pt.Y + dy);                    
                }
            }
        }
        public override void Draw(Graphics g)
        {
            foreach (Figure f in groupFig) f.Draw(g);            
        }
        public override bool PointInObj(Point p)
        {
                       
            return false; 
        }
        public override string ToString()
        {
            return "agregation";
        }
        public override string FigInfo()
        {
            string info =  "A " + point.X + " " + point.Y + " " + color.R + " " + color.G + " " + color.B + " " + groupFig.Count + " ";
            for (int i = 0; i < groupFig.Count-1; i++) { info += groupFig[i].FigInfo() + " "; }
            info += groupFig[groupFig.Count - 1].FigInfo();
            return info;            
        }
    }
}
