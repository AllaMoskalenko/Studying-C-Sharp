namespace HomeWork01
    /*
     Ввести радиус круга R и угол t
     * Нарисовать график функций x= R * sin t; y = R * cos t
     * */

{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x, y, x0, y0, t, t1, r;
            t = Convert.ToInt32(textBox1.Text);
            r = Convert.ToInt32(textBox2.Text);
            x = pictureBox1.Width /2;
            y = pictureBox1.Height /2;
            y0 = 0;
            x0 = 0;
            t1 = 0;

            //draw coordinate axis
            Pen p1 = new Pen(Color.Blue, 2);
            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.DrawLine(p1, x0 , y , 2*x, y);
            graphics.DrawLine(p1, x , y0 , x, 2*y);   
            
            //draw circle
            Pen p2 = new Pen(Color.Black, 1);
            while (t1 < t)
            {
                graphics.DrawLine(p2, x+ Convert.ToInt32(r*Math.Sin(t1*Math.PI/180)), y - Convert.ToInt32(r*Math.Cos(t1*Math.PI / 180)),
                                      x + Convert.ToInt32(r * Math.Sin((t1+1)* Math.PI / 180)), y - Convert.ToInt32(r * Math.Cos((t1+1)* Math.PI / 180)));
                t1++;
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
