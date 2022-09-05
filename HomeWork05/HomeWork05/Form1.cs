namespace HomeWork05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            int n, l, p;
            n = Convert.ToInt32(textBox1.Text);
            l = Convert.ToInt32(textBox2.Text);

            Figure figure = new Figure(n, l);
           
            label4.Text = "Perimeter is " + figure.Perimeter(n, l);
            label5.Text = "Area is " + Math.Round(figure.Area(n, l));
            label6.Text = "Inner corner is " + figure.Corner(n);

            Graphics g = pictureBox1.CreateGraphics();
            figure.Drawing(g, pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            textBox1.Text = "";
            textBox2.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}