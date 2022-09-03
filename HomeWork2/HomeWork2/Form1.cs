namespace HomeWork2
/*
Задача:
1. ввести массив из N элементов и показать его;
2. сделать реверс(расположить элементы в обратном порядке) этого массива и показать его;
3. из итогового массива показать все четные числа.
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
            int n, y, b;
            n = Convert.ToInt32(textBox1.Text);
            int[] a, z;
            a = new int[n];
            //input elements
            for (int i = 0; i < n; i++)
            {
                a[i] = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Input element:"));
                listBox1.Items.Add(a[i]);
            }
            //reverse
            z = new int[n];
            y = n;
            b = 0;
            for (int i = 0; i < n; i++)
            {
                z[i] = a[y-1];
                listBox2.Items.Add(z[i]);
                y--;
                if (z[i] % 2 == 0)
                {
                    listBox3.Items.Add(z[i]);
                    b++;
                }
             }
             if (b == 0)
            {
                label2.Text = "There are no even elements in array!";
            } else
            {
                label2.Text = " ";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); 
            listBox2.Items.Clear(); 
            listBox3.Items.Clear(); 

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
