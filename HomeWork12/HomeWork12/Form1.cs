namespace HomeWork12
{
    public partial class Form1 : Form
    {
        Matrix_3x3[] matrices;
        Matrix_3x3 sumMatr;
        public Form1()
        {
            InitializeComponent();

            string f1;
            f1 = System.IO.Path.GetFullPath("Matrix.txt");
            FileStream fs = File.OpenRead(f1);
            StreamReader sr = new StreamReader(f1);

            //count our matrix
            int counter = 0;
            string line;
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                counter++;
            }
            sr.Close();

            sr = new StreamReader(f1);
            matrices = new Matrix_3x3[counter];
            int[,] newMatr = new int[3, 3];
            string[] matr;
            int c = 0;

            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                matr = line.Split(" ");
                for (int i = 0; i < 3; i++)
                {
                    newMatr[0, i] = Convert.ToInt32(matr[i]);
                }
                for (int i = 0; i < 3; i++)
                {
                    newMatr[1, i] = Convert.ToInt32(matr[i + 3]);
                }
                for (int i = 0; i < 3 ; i++)
                {
                    newMatr[2, i] = Convert.ToInt32(matr[i + 6]);
                }
                matrices[c] = new Matrix_3x3(newMatr);
                
                comboBox1.Items.Add("Matrix " + (c + 1));
                comboBox2.Items.Add("Matrix " + (c + 1));
                
                c++;
            }
            sr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num;
            num = comboBox1.SelectedIndex;
            richTextBox1.Text = matrices[num].ShowMatrix();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num;
            num = comboBox2.SelectedIndex;
            richTextBox2.Text = matrices[num].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int com1, com2;
            com1 = comboBox1.SelectedIndex;
            com2 = comboBox2.SelectedIndex;
            sumMatr = new Matrix_3x3();
            sumMatr = Matrix_3x3.Add(matrices[com1], matrices[com2]);
            richTextBox3.Text = sumMatr.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int a;
            
            if (richTextBox1.Text != "") 
            {
                 a = comboBox1.SelectedIndex;
                 textBox1.Text = matrices[a].Determinant().ToString();
            }
            if (richTextBox2.Text != "")
            {
                a = comboBox2.SelectedIndex;
                textBox2.Text = matrices[a].Determinant().ToString();
            }
            if (richTextBox3.Text != "")
            {
                
                textBox3.Text = sumMatr.Determinant().ToString();
            }

        }
    }
}