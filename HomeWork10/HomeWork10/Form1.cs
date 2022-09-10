namespace HomeWork10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Circle[] circles;
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            comboBox1.Items.Clear();
            
            int m = 0;
            int x1, y1, diam;

            m = Convert.ToInt32(textBox1.Text);
            circles = new Circle[m];
            for (int i = 0; i < m; i++)
            {
                x1 = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Input X:"));
                y1 = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Input Y:"));
                diam = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Input Diameter:"));
                circles[i] = new Circle(x1, y1, diam, i%5);
                comboBox1.Items.Add(i+1);
            }

            Graphics g = pictureBox1.CreateGraphics();
            for (int i = 0; i < m; i++)
            {
                circles[i].Draw(g);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int x2,y2, circleNum;
            x2 = Convert.ToInt32(textBox2.Text);
            y2 = Convert.ToInt32(textBox3.Text);
            circleNum = comboBox1.SelectedIndex;
            if (circleNum != -1)
            {
                pictureBox1.Refresh();
                Graphics g = pictureBox1.CreateGraphics();
                circles[circleNum].Move(x2,y2);
                for (int i = 0; i < circles.Length; i++)
                {
                    circles[i].Draw(g);
                }          
            }
            
        }
    }
}