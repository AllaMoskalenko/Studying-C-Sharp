namespace HomeWork17
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";            
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = 0;
            int err = 0;
            string line = textBox1.Text.ToString();

            for (int i = 0; i < line.Length; i++)
            {
                if (k >= 0)
                {
                    if (line[i] == '(')
                    {
                        k++;
                        err = i;
                    }

                    if (line[i] == ')')
                    {
                        k--;
                        if (k == 0) err = 0;
                        else err = i;
                    }
                }
                else
                {
                    label2.Text = "Your text uncorrect! Check " + i + " symbol!";
                    break;
                }
            }
            if (k == 0)
            {
                label2.Text = "Your text is correct!";
            }
            else
            {
                label2.Text = "Your text is uncorrect! Check " + (err + 1) + " symbol!";
            }
        }
    }
}