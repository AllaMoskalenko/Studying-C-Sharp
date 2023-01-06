using SortingAlgorythms;
using System.Windows.Forms;

namespace HomeWork20
{
    public partial class Form1 : Form
    {
        public int[] array;
        public static int max_value;
        public Form1()
        {
            InitializeComponent();
            Sort.Init(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = Sort.bmp;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button1_Click(object sender, EventArgs e)   //Create array
        {
            max_value = 400;
            int amount = 90;
            string val, amo;
            val = textBox2.Text;
            amo = textBox1.Text;
            if (val != "" ) max_value = Convert.ToInt32(val);
            if (amo != "" )  amount = Convert.ToInt32(amo);
            Sort.max = max_value;
            array = new int[amount];
            Random rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                array[i] = rand.Next(1,max_value);
            }
            Sort.DrawArr(array);
            pictureBox1.Image = Sort.bmp;
        }

        private void button2_Click(object sender, EventArgs e)    //mixing array elements
        {
            Random rand = new Random();
            int temp;
            for (int i = array.Length-1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                temp = array[j];
                array[j] = array[i];
                array[i] = temp;
            }
            Sort.DrawArr(array);
            pictureBox1.Image = Sort.bmp;
        }

        private void button3_Click(object sender, EventArgs e)   //bubble sort
        {
            array = Sort.BubbleSort(array, ref pictureBox1);
            
        }

        
        private void button8_Click(object sender, EventArgs e)   // gnome sort
        {
            array = Sort.GnomeSort(array, ref pictureBox1);
        }

        private void button4_Click(object sender, EventArgs e)  // selection sort
        {
            array = Sort.SelectionSort(array, ref pictureBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            array = Sort.InsertionSort(array, ref pictureBox1);
        }
    }
}