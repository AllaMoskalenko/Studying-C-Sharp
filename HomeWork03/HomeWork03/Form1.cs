namespace HomeWork03
/*
 * Задача:
1. ввести последовательность из N точек (по координатно);
2. построить ломаную линию по этим точкам.
*3. посчитать длину этой ломаной линии.
 */
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n, x, x0, y, y0;
            //n = 0;
            Point[] mas;
            n = Convert.ToInt32(textBox1.Text);
            mas = new Point[n];
            for (int i = 0; i < n; i++)
            {
                mas[i].X = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Input X:"));
                mas[i].Y = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Input Y:"));
            }
            //create axes 
            x0 = 0;
            y0 = 0;
            x = pictureBox1.Width / 2;
            y = pictureBox1.Height / 2;
            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.Blue, 2);
            graphics.DrawLine(pen, x0, y, 2*x, y);
            graphics.DrawLine(pen, x, y0, x, 2*y);

            //create lines
            for (int i = 0; i < n - 1; i++) 
            {
                graphics.DrawLine(pen, mas[i].X+x, -mas[i].Y+y, mas[i+1].X+x, -mas[i+1].Y+y);

            }

            //length all lines
            double l = 0;
            for (int i = 0; i < n-1; i++)
            {
                l += Math.Sqrt(Math.Pow(mas[i].X - mas[i + 1].X, 2) + Math.Pow(mas[i + 1].Y - mas[i].Y, 2));
            }
            if (l == 0)
            {
                label2.Text = "";
            }
            else
            {
                label2.Text = "Lines length is " + Math.Round(l);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}