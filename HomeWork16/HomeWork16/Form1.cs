using System.Threading.Channels;
using System.Windows.Forms;

namespace HomeWork16
{
    public partial class Form1 : Form
    {
        List <Figure> figures = new List<Figure>();
        //Agregation agregation;
        Circle circle;
        Rectangle rect;
        Polygon poly;
        Star star;
        Bitmap bmp;
        Graphics gbmp;
        bool mouseDown, mouseUp;
        int selector = -1, k = 0;            //k - counter selected figures; selector - index selected figure (-1 if nothing selected)
        Point p0, pA;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gbmp = Graphics.FromImage(bmp);
        }
        private void button19_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button20_Click(object sender, EventArgs e)  //clear all objects
        {
            gbmp.Clear(Color.White);
            pictureBox1.Image = bmp;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            figures.Clear();
            //agregation.Clear();
        }      
        private void button1_Click(object sender, EventArgs e)         //creating temporary circle
        {
            selector = -1;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel1.Location = new Point(710, 95);

            gbmp.Clear(Color.White);
            Point p = new Point();
            p.X = pictureBox1.Width / 2;
            p.Y = pictureBox1.Height / 2;
            circle = new Circle(p, Color.Gray, 50);                     
            circle.Draw(gbmp);
            pictureBox1.Image = bmp;
            
        }
        private void button4_Click(object sender, EventArgs e)         //create temporary star
        {
            selector = -1;
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel2.Location = new Point(710, 95);
            
            gbmp.Clear(Color.White);
            Point p = new Point();
            p.X = pictureBox1.Width / 2;
            p.Y = pictureBox1.Height / 2;
            star = new Star(p, Color.Gray, 8, 25, 50);
            star.Draw(gbmp);
            pictureBox1.Image = bmp;
        }
        private void button2_Click(object sender, EventArgs e)         //creating temporary rectangle
        {
            selector = -1;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Location = new Point(710, 95);
            gbmp.Clear(Color.White);
            Point p = new Point();
            p.X = pictureBox1.Width / 2;
            p.Y = pictureBox1.Height / 2;
            rect = new Rectangle(p, Color.Gray, 60, 40);
            rect.Draw(gbmp);
            pictureBox1.Image = bmp;
        }
        private void button3_Click(object sender, EventArgs e)         //create temp polygon
        {
            selector = -1;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel4.Location = new Point(710, 95);
            gbmp.Clear(Color.White);
            Point p = new Point();
            p.X = pictureBox1.Width / 2;
            p.Y = pictureBox1.Height / 2;
            poly = new Polygon(p, Color.Gray, 5, 30);
            poly.Draw(gbmp);
            pictureBox1.Image = bmp;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)      //change circle size 
        {
            if (selector == -1)
            {
                circle.radius = trackBar1.Value;
                gbmp.Clear(Color.White);
                circle.Draw(gbmp);
            }
            else
            {
                ((Circle)figures[selector]).radius = trackBar1.Value;
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)     //moving circle horizontally
        {
            if (selector == -1)
            {
                circle.pt = new Point(trackBar2.Value, circle.pt.Y);
                gbmp.Clear(Color.White);
                circle.Draw(gbmp);
            }
            else
            {
                ((Circle)figures[selector]).pt = new Point (trackBar2.Value, ((Circle)figures[selector]).pt.Y);
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }            
            pictureBox1.Image = bmp;
        }
        private void trackBar3_Scroll(object sender, EventArgs e)      //moving circle vertically
        {
            if (selector == -1)
            {
                circle.pt = new Point (circle.pt.X, trackBar3.Value);
                gbmp.Clear(Color.White);
                circle.Draw(gbmp);
            }
            else
            {
                ((Circle)figures[selector]).pt = new Point(((Circle)figures[selector]).pt.X, trackBar3.Value);
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void button5_Click(object sender, EventArgs e)         //change circle color
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog()== DialogResult.OK)
            {
                if (selector == -1)
                {
                    circle.color = cd.Color;
                    gbmp.Clear(Color.White);
                    circle.Draw(gbmp);
                }
                else
                {
                    ((Circle)figures[selector]).color = cd.Color;
                    gbmp.Clear(Color.White);
                    figures[selector].Draw(gbmp);
                }
                pictureBox1.Image = bmp;
            }
        }
        private void button8_Click(object sender, EventArgs e)        //add circle to main picture
        {
            if (selector == -1)
            {
                figures.Add(new Circle(circle.pt, circle.color, circle.radius));
            }
            panel1.Visible = false;
            gbmp.Clear(Color.White);
            for (int i=0; i < figures.Count; i++)
            {
                figures[i].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void button13_Click(object sender, EventArgs e)       //cancel adding of circle
        {
            panel1.Visible = false;
            gbmp.Clear(Color.White);
            for (int i = 0; i < figures.Count; i++)
            {
                figures[i].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void trackBar11_Scroll(object sender, EventArgs e)    //change width of rectangle
        {
            if (selector == -1)
            {
                rect.width = trackBar11.Value;
                gbmp.Clear(Color.White);
                rect.Draw(gbmp);
            }
            else
            {
                ((Rectangle)figures[selector]).width = trackBar11.Value;
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void trackBar8_Scroll(object sender, EventArgs e)     //change height of rectangle
        {
            if (selector == -1)
            {
                rect.height = trackBar8.Value;
                gbmp.Clear(Color.White);
                rect.Draw(gbmp);
            }
            else
            {
                ((Rectangle)figures[selector]).height = trackBar8.Value;
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void trackBar10_Scroll(object sender, EventArgs e)   //moving rectangle horizontally
        {
            if (selector == -1)
            {
                rect.pt = new Point(trackBar10.Value, rect.pt.Y);
                gbmp.Clear(Color.White);
                rect.Draw(gbmp);
            }
            else
            {
                ((Rectangle)figures[selector]).pt = new Point(trackBar10.Value, ((Rectangle)figures[selector]).pt.Y);
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void trackBar9_Scroll(object sender, EventArgs e)    //moving rectangle vertically
        {
            if (selector == -1)
            {
                rect.pt = new Point(rect.pt.X, trackBar9.Value);
                gbmp.Clear(Color.White);
                rect.Draw(gbmp);
            } else
            {
                ((Rectangle)figures[selector]).pt = new Point (((Rectangle)figures[selector]).pt.X, trackBar9.Value);
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void button12_Click(object sender, EventArgs e)      //change rectangle color
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                if (selector == -1)
                {
                    rect.color = cd.Color;
                    gbmp.Clear(Color.White);
                    rect.Draw(gbmp);
                }
                else
                {
                    ((Rectangle)figures[selector]).color = cd.Color;
                    gbmp.Clear(Color.White);
                    figures[selector].Draw(gbmp);
                }
                pictureBox1.Image = bmp;
            }
        }
        private void button15_Click(object sender, EventArgs e)      //cancel adding of rectangle
        {
            panel3.Visible = false;
            gbmp.Clear(Color.White);
            for (int i = 0; i < figures.Count; i++)
            {
                figures[i].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void button11_Click(object sender, EventArgs e)      //add rectangle to main picture
        {
            if (selector == -1)
            {
                figures.Add(new Rectangle(rect.pt, rect.color, rect.width, rect.height));
            }
            panel3.Visible = false;
            gbmp.Clear(Color.White);
            for (int i = 0; i < figures.Count; i++)
            {
                figures[i].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void trackBar15_Scroll(object sender, EventArgs e)   // change size of polygon
        {
            if (selector == -1)
            {
                poly.radius = trackBar15.Value;
                gbmp.Clear(Color.White);
                poly.Draw(gbmp);
            }
            else
            {
                ((Polygon)figures[selector]).radius = trackBar15.Value;
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void trackBar12_Scroll(object sender, EventArgs e)   //change num of tops in polygon
        {
            if (selector == -1)
            {
                poly.tops = trackBar12.Value;
                gbmp.Clear(Color.White);
                poly.Draw(gbmp);
            }
            else
            {
                ((Polygon)figures[selector]).tops = trackBar12.Value;
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void trackBar14_Scroll(object sender, EventArgs e)   //moving polygon horizontally
        {
            if (selector == -1)
            {
                poly.pt = new Point(trackBar14.Value, poly.pt.Y);
                gbmp.Clear(Color.White);
                poly.Draw(gbmp);
            } else
            {
                ((Polygon)figures[selector]).pt = new Point(trackBar14.Value, ((Polygon)figures[selector]).pt.Y);
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void trackBar13_Scroll(object sender, EventArgs e)  //moving polygon vertically
        {
            if (selector == -1)
            {
                poly.pt = new Point(poly.pt.X, trackBar13.Value);
                gbmp.Clear(Color.White);
                poly.Draw(gbmp);
            }
            else
            {
                ((Polygon)figures[selector]).pt = new Point(((Polygon)figures[selector]).pt.X, trackBar13.Value);
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void button18_Click(object sender, EventArgs e)     //change polygon color
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                if (selector == -1)
                {
                    poly.color = cd.Color;
                    gbmp.Clear(Color.White);
                    poly.Draw(gbmp);
                } else
                {
                    ((Polygon)figures[selector]).color = cd.Color;
                    gbmp.Clear(Color.White);
                    figures[selector].Draw(gbmp);
                }
                pictureBox1.Image = bmp;
            }
        }
        private void button16_Click(object sender, EventArgs e)     //cancel adding of polygon
        {
            panel4.Visible = false;
            gbmp.Clear(Color.White);
            for (int i = 0; i < figures.Count; i++)
            {
                figures[i].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }
        private void button17_Click(object sender, EventArgs e)     //add polygon to main picture
        {
            if (selector == -1) { figures.Add(new Polygon(poly.pt, poly.color,poly.tops, poly.radius)); }
            panel4.Visible = false;
            gbmp.Clear(Color.White);
            for (int i = 0; i < figures.Count; i++)
            {
                figures[i].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }

        private void trackBar6_Scroll(object sender, EventArgs e)   //change radius1 in star 
        {
            if (selector == -1)
            {
                star.radius1 = trackBar6.Value;
                gbmp.Clear(Color.White);
                star.Draw(gbmp);
            }
            else
            {
                ((Star)figures[selector]).radius1 = trackBar6.Value;
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }

        private void trackBar16_Scroll(object sender, EventArgs e)  //change radius2 in star 
        {
            if (selector == -1)
            {
                star.radius2 = trackBar16.Value;
                gbmp.Clear(Color.White);
                star.Draw(gbmp);
            } else
            {
                ((Star)figures[selector]).radius2 = trackBar16.Value;
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }

        private void trackBar7_Scroll(object sender, EventArgs e)   //change amount of tops in star
        {
            if (selector == -1)
            {
                star.tops = trackBar7.Value;
                gbmp.Clear(Color.White);
                star.Draw(gbmp);
            } else
            {
                ((Star)figures[selector]).tops = trackBar7.Value;
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }

        private void trackBar5_Scroll(object sender, EventArgs e)   //moving star horizontally
        {
            if (selector == -1)
            {
                star.pt = new Point(trackBar5.Value, star.pt.Y);
                gbmp.Clear(Color.White);
                star.Draw(gbmp);
            } else
            {
                ((Star)figures[selector]).pt = new Point(trackBar5.Value, ((Star)figures[selector]).pt.Y);
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)  //moving star vertically
        {
            if (selector == -1)
            {
                star.pt = new Point(star.pt.X, trackBar4.Value);
                gbmp.Clear(Color.White);
                star.Draw(gbmp);
            } else
            {
                ((Star)figures[selector]).pt = new Point(((Star)figures[selector]).pt.X, trackBar4.Value);
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }

        private void button10_Click(object sender, EventArgs e)    //change star color
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                if (selector == -1)
                {
                    star.color = cd.Color;
                    gbmp.Clear(Color.White);
                    star.Draw(gbmp);
                }
                else
                {
                    ((Star)figures[selector]).color = cd.Color;
                    gbmp.Clear(Color.White);
                    figures[selector].Draw(gbmp);
                }
                pictureBox1.Image = bmp;
            }
        }

        private void button14_Click(object sender, EventArgs e)    //cancel adding of star
        {            
            panel2.Visible = false;
            gbmp.Clear(Color.White);
            for (int i = 0; i < figures.Count; i++)
            {
                figures[i].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }

        private void button9_Click(object sender, EventArgs e)      //add star to main picture
        {
            if (selector == -1)
            {
                figures.Add(new Star(star.pt, star.color, star.tops, star.radius1, star.radius2));
            }
            panel2.Visible = false;
            gbmp.Clear(Color.White);
            for (int i = 0; i < figures.Count; i++)
            {
                figures[i].Draw(gbmp);
            }
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseUp = true;
            mouseDown = false;
            gbmp.Clear(Color.White);
            
            if (panel1.Visible)
            {
                circle.Draw(gbmp);
            }
            else if (panel2.Visible)
            {
                star.Draw(gbmp);
            }
            else if (panel3.Visible)
            {
                rect.Draw(gbmp);
            }
            else if (panel4.Visible)
            {
                poly.Draw(gbmp);
            }
            else if (panel5.Visible)
            {
                figures[selector].Draw(gbmp);
            }
            else
            {
                for (int i = 0; i < figures.Count; i++)
                {
                    figures[i].Draw(gbmp);
                }
            }
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //label20.Text = figures.Count().ToString();
            //foreach(Figure f in figures) { if (f.ToString() == "agregation") label20.Text += "(I have an agregation)"; }
            
            Point pmin = new Point();
            Point pmax = new Point();
            Point p = new Point(e.X, e.Y);

            if (mouseDown)
            {
                if (panel1.Visible)
                {
                    if (circle.PointInObj(p))
                    {
                        gbmp.Clear(Color.White);
                        circle.pt = new Point (p.X, p.Y);
                        circle.Draw(gbmp);
                    }
                }
                else
                    if (panel2.Visible)
                {
                    if (star.PointInObj(p))
                    {
                        gbmp.Clear(Color.White);
                        star.pt = new Point (p.X, p.Y);                        
                        star.Draw(gbmp);
                    }
                }
                else
                    if (panel3.Visible)
                {
                    if (rect.PointInObj(p))
                    {
                        gbmp.Clear(Color.White);
                        rect.pt = new Point (p.X, p.Y);
                        rect.Draw(gbmp);
                    }
                }
                else
                    if (panel4.Visible)
                {
                    if (poly.PointInObj(p))
                    {
                        gbmp.Clear(Color.White);
                        poly.pt = new Point(p.X, p.Y);                        
                        poly.Draw(gbmp);
                    }
                }
                else
                    if (panel5.Visible)
                {
                    if (figures[selector].PointInObj(p))
                    {
                        gbmp.Clear(Color.White);    
                        figures[selector].pt = new Point(p.X, p.Y);                        
                        figures[selector].Draw(gbmp);
                    }
                }
                else
                {
                    for (int i = 0; i < figures.Count; i++)
                    {
                        figures[i].is_selected = false;
                    }
                    gbmp.Clear(Color.White);
                    
                    if (p0.X > p.X)
                    {
                        pmin.X = p.X;
                        pmax.X = p0.X;
                    }
                    else
                    {
                        pmin.X = p0.X;
                        pmax.X = p.X;
                    }
                    if (p0.Y > p.Y)
                    {
                        pmin.Y = p.Y;
                        pmax.Y = p0.Y;
                    }
                    else
                    {
                        pmin.Y = p0.Y;
                        pmax.Y = p.Y;
                    }
                    k = 0;
                    for (int i = 0; i<figures.Count; i++)
                    {
                        if (figures[i].pt.X < pmax.X && figures[i].pt.X > pmin.X &&
                            figures[i].pt.Y < pmax.Y && figures[i].pt.Y > pmin.Y)
                        {
                            figures[i].is_selected = true;
                            k++;
                        }
                    }
                    for (int i = 0; i < figures.Count; i++) figures[i].Draw(gbmp);
                    gbmp.FillRectangle(new SolidBrush(Color.FromArgb(100, 0, 0, 255)), pmin.X, pmin.Y, pmax.X - pmin.X, pmax.Y - pmin.Y);
                    gbmp.DrawRectangle(new Pen(Color.FromArgb(255, 0, 0, 255)), pmin.X, pmin.Y, pmax.X - pmin.X, pmax.Y - pmin.Y);

                }
            }
            pictureBox1.Image = bmp;

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            if (p.X == p0.X && p.Y == p0.Y && panel5.Visible == false)
            {
                selector = -1;
                for (int i = 0; i < figures.Count; i++)
                {
                    figures[i].is_selected = false;
                    k = 0;
                }
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].PointInObj(p))
                    {
                        figures[i].is_selected = true;
                        figures[i].Draw(gbmp);
                        selector = i;
                        break;
                    }
                }
                pictureBox1.Image = bmp;
            }
            else if (k == 1)
            {
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].is_selected)
                    {
                        selector = i;                        
                        break;
                    }
                }
            }
        }

        private void trackBar18_Scroll(object sender, EventArgs e)  //moving agregation horizontally
        { 
            figures[selector].pt = new Point(trackBar18.Value, figures[selector].pt.Y);
            gbmp.Clear(Color.White);
            figures[selector].Draw(gbmp);      
            pictureBox1.Image = bmp;
        }

        private void trackBar17_Scroll(object sender, EventArgs e)   //moving agregation vertically
        {
            figures[selector].pt = new Point(figures[selector].pt.X, trackBar17.Value);
            gbmp.Clear(Color.White);
            figures[selector].Draw(gbmp);
            pictureBox1.Image = bmp;
        }

        private void button23_Click(object sender, EventArgs e)  //additing  edited agregation (OK)
        {
            //figures[selector].is_selected = false;
            selector = -1;
            k = 0;
            panel5.Visible = false;
            gbmp.Clear(Color.White);
            for (int i = 0; i < figures.Count; i++) 
            {
                figures[i].is_selected = false;
                figures[i].Draw(gbmp); }
            pictureBox1.Image = bmp;
        }

        private void button24_Click(object sender, EventArgs e)  //change agregation color
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {

                figures[selector].color = cd.Color;
                gbmp.Clear(Color.White);
                figures[selector].Draw(gbmp);
                pictureBox1.Image = bmp;
            }
        }

        private void button7_Click(object sender, EventArgs e)                 //ungrouping
        {
            if (k == 1)
            {
                List<Figure> temp = new List<Figure>();
                temp = ((Agregation)figures[selector]).groupFig;
                for (int i = 0; i < temp.Count; i ++)
                {
                    if (temp[i].ToString() == "circle")     { figures.Add(new Circle(temp[i].pt, temp[i].color, ((Circle)temp[i]).radius)); }
                    if (temp[i].ToString() == "rectangle")  { figures.Add(new Rectangle(temp[i].pt, temp[i].color, ((Rectangle)temp[i]).width, ((Rectangle)temp[i]).height)); }
                    if (temp[i].ToString() == "star")       { figures.Add(new Star(temp[i].pt, temp[i].color, ((Star)temp[i]).tops, ((Star)temp[i]).radius1, ((Star)temp[i]).radius2)); }
                    if (temp[i].ToString() == "polygon")    { figures.Add(new Polygon(temp[i].pt, temp[i].color, ((Polygon)temp[i]).tops, ((Polygon)temp[i]).radius)); }
                    if (temp[i].ToString() == "agregation") { figures.Add(new Agregation(((Agregation)temp[i]).groupFig, temp[i].pt)); }
                }
                figures.RemoveAt(selector);
                selector = -1;
                k = 0;
                gbmp.Clear(Color.White);
                for (int i = 0; i < figures.Count; i++) figures[i].Draw(gbmp);
                pictureBox1.Image = bmp;
            }
        }

        private void button22_Click(object sender, EventArgs e)              //save in file
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDir, "figures.txt");
            FileStream fs = File.Create(filePath);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < figures.Count; i++)
            {
                sw.WriteLine(figures[i].FigInfo());
            }
            
            sw.Close();
            fs.Close();
            MessageBox.Show("Save successfully in file 'figures.txt'");

        }
        Agregation readAgregation(String[]f, ref int smeschenie,Point boba)
        {
            List<Figure> biba = new List<Figure>();
            int x;
            int y;
            int r;
            int g;
            int b;
            int num = int.Parse(f[smeschenie - 1]);
            for (int i = 0; i < num; i++)//i - это счетчик внутренних фигур
            {
                x = int.Parse(f[smeschenie + 1]);
                y = int.Parse(f[smeschenie + 2]);
                r = int.Parse(f[smeschenie + 3]);
                g = int.Parse(f[smeschenie + 4]);
                b = int.Parse(f[smeschenie + 5]);
                if (f[smeschenie] == "C")
                {
                    int r1 = int.Parse(f[smeschenie + 6]);
                    smeschenie += 7;
                    biba.Add(new Circle(new Point(x, y), Color.FromArgb(r, g, b), r1));
                }
                else if (f[smeschenie] == "R")
                {
                    int r1 = int.Parse(f[smeschenie + 6]);
                    int r2 = int.Parse(f[smeschenie + 7]);
                    smeschenie += 8;
                    biba.Add(new Rectangle(new Point(x, y), Color.FromArgb(r, g, b), r1, r2));
                }
                else if (f[smeschenie] == "P")
                {
                    int n = int.Parse(f[smeschenie + 6]);
                    int r1 = int.Parse(f[smeschenie + 7]);
                    smeschenie += 8;
                    biba.Add(new Polygon(new Point(x, y), Color.FromArgb(r, g, b), n, r1));
                }
                else if (f[smeschenie] == "S")
                {
                    int n = int.Parse(f[smeschenie + 6]);
                    int r1 = int.Parse(f[smeschenie + 7]);
                    int r2 = int.Parse(f[smeschenie + 8]);
                    smeschenie += 9;
                    biba.Add(new Star(new Point(x, y), Color.FromArgb(r, g, b), n, r1, r2));
                }
                else if (f[smeschenie] == "A")
                {
                    biba.Add(readAgregation(f, ref smeschenie, new Point(x,y)));
                }
            }
            return new Agregation(biba, boba);
        }
        private void button25_Click(object sender, EventArgs e)            //read from file
        {
            string file = System.IO.Path.GetFullPath("figures.txt");
            if (File.Exists(file))
            {
                FileStream fs = File.OpenRead(file);
                StreamReader sr = new StreamReader(fs);
                string line;
                String[] f;
                int x, y, r, g, b, n, r1, r2;      
                figures.Clear();
                while (sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    f = line.Split();

                    x = int.Parse(f[1]);
                    y = int.Parse(f[2]);
                    Point boba = new Point(x, y);
                    r = int.Parse(f[3]);
                    g = int.Parse(f[4]);
                    b = int.Parse(f[5]);
                    if (f[0] == "C")
                    {
                        r1 = int.Parse(f[6]);
                        figures.Add(new Circle(new Point(x, y), Color.FromArgb(r, g, b), r1));
                    }
                    else if (f[0] == "R")
                    {
                        r1 = int.Parse(f[6]);
                        r2 = int.Parse(f[7]);
                        figures.Add(new Rectangle(new Point(x, y), Color.FromArgb(r, g, b), r1, r2));
                    }
                    else if (f[0] == "P")
                    {
                        n = int.Parse(f[6]);
                        r1 = int.Parse(f[7]);
                        figures.Add(new Polygon(new Point(x, y), Color.FromArgb(r, g, b), n, r1));
                    }
                    else if (f[0] == "S")
                    {
                        n = int.Parse(f[6]);
                        r1 = int.Parse(f[7]);
                        r2 = int.Parse(f[8]);
                        figures.Add(new Star(new Point(x, y), Color.FromArgb(r, g, b), n, r1, r2));
                    }
                    else if (f[0] == "A")
                    {
                        int smeschenie = 7;
                        List<Figure> ahahah = new List<Figure>();
                        int num = int.Parse(f[smeschenie-1]);
                        for (int i = 0 ;i < num; i++)//i - это счетчик внутренних фигур
                        {
                            x = int.Parse(f[smeschenie + 1]);
                            y = int.Parse(f[smeschenie + 2]);
                            r = int.Parse(f[smeschenie + 3]);
                            g = int.Parse(f[smeschenie + 4]);
                            b = int.Parse(f[smeschenie + 5]);
                            if (f[smeschenie] == "C")
                            {
                                r1 = int.Parse(f[smeschenie + 6]);
                                smeschenie += 7;
                                ahahah.Add(new Circle(new Point(x, y), Color.FromArgb(r, g, b), r1));
                            }
                            else if (f[smeschenie] == "R")
                            {
                                r1 = int.Parse(f[smeschenie+6]);
                                r2 = int.Parse(f[smeschenie+7]);
                                smeschenie += 8;
                                ahahah.Add(new Rectangle(new Point(x, y), Color.FromArgb(r, g, b), r1, r2));
                            }
                            else if (f[smeschenie] == "P")
                            {
                                n = int.Parse( f[smeschenie+6]);
                                r1 = int.Parse(f[smeschenie+7]);
                                smeschenie += 8;
                                ahahah.Add(new Polygon(new Point(x, y), Color.FromArgb(r, g, b), n, r1));
                            }
                            else if (f[smeschenie] == "S")
                            {
                                n = int.Parse( f[smeschenie+6]);
                                r1 = int.Parse(f[smeschenie+7]);
                                r2 = int.Parse(f[smeschenie+8]);
                                smeschenie += 9;
                                ahahah.Add(new Star(new Point(x, y), Color.FromArgb(r, g, b), n, r1, r2));
                            }
                            else if (f[smeschenie] == "A")
                            {
                                smeschenie += 7;
                                ahahah.Add(readAgregation(f, ref smeschenie, new Point(x, y)));
                            }
                        }
                        figures.Add(new Agregation(ahahah, boba));
                    }


                }
                sr.Close();
                fs.Close();
                gbmp.Clear(Color.White);
                for (int i = 0; i < figures.Count; i++) figures[i].Draw(gbmp);
                pictureBox1.Image = bmp;
            }
            else
            {
                MessageBox.Show("File 'figures.txt' not found!");
            }
        }

        private void button21_Click(object sender, EventArgs e)                     //edit selected figures
        {
            if (selector >= 0)
            {
                //label19.Text = figures[selector].FigInfo();
                if (figures[selector].ToString() == "circle")     { panel1.Visible = true; button13.Enabled = false; }
                if (figures[selector].ToString() == "rectangle")  { panel3.Visible = true; button15.Enabled = false; }
                if (figures[selector].ToString() == "star")       { panel2.Visible = true; button14.Enabled = false; }
                if (figures[selector].ToString() == "polygon")    { panel4.Visible = true; button16.Enabled = false; }
                if (figures[selector].ToString() == "agregation") { panel5.Location = new Point(710, 95); panel5.Visible = true;  }
                }
        }

        private void button6_Click(object sender, EventArgs e)     // creating agregation
        {
            
            if (k > 1)
            {  
                List<Figure> groupFig = new List<Figure>();
                pA = new Point();
                
                for (int i = 0; i < figures.Count; i++)
                {
                    if (figures[i].is_selected)
                    {
                        groupFig.Add(figures[i]);
                        pA.X += figures[i].pt.X;
                        pA.Y += figures[i].pt.Y;
                        figures.RemoveAt(i);
                        i--;
                    }
                }
                pA.X = pA.X / groupFig.Count;
                pA.Y = pA.Y / groupFig.Count;
                for (int i = 0; i < figures.Count; i++) figures[i].is_selected = false;
                k = 0;
                selector = -1;
                figures.Add(new Agregation(groupFig, pA));
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            p0.X = e.X;
            p0.Y = e.Y;
            mouseDown = true;
        }
    }
}