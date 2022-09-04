namespace HomeWork04
    /* Calculator for complex numbers*/
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }
        int flag = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            flag = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flag = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Complex first = new Complex(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text));  
            Complex second = new Complex(Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text));
            Complex result = new Complex();
            //addition
            if (flag == 1)
            {
                result = Complex.Add(first, second);
                textBox5.Text = result.r.ToString();
                textBox6.Text = result.i.ToString();
            }

            //subtraction
            else if (flag == 2)
            {
                result = Complex.Sub(first, second);
                textBox5.Text = result.r.ToString();
                textBox6.Text = result.i.ToString();
            }

            //multiplication
            else if (flag == 3)
            {
                result = Complex.Mul(first, second);
                textBox5.Text = result.r.ToString();
                textBox6.Text = result.i.ToString();
            }

            //division
            else if (flag == 4)
            {
                result = Complex.Div(first, second);
                textBox5.Text = result.r.ToString();
                textBox6.Text = result.i.ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}