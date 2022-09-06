namespace HomeWork06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Massiv mass;
        private void createTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mass = new Massiv(11 - trackBar2.Value, 
                trackBar1.Value, 
                Convert.ToInt32(comboBox2.SelectedItem.ToString()),
                Convert.ToInt32(comboBox1.SelectedItem.ToString()));
            for (int i = 0; i < mass.n; i++)
            {
                dataGridView1.Columns.Add("col"+(i+1).ToString(),(i+1).ToString());
                dataGridView1.Columns["col" + (i + 1).ToString()].Width = 40;
            }
            for (int i = 0; i < mass.m; i++)
            {
                dataGridView1.Rows.Add();
            }

            for (int i = 0; i < mass.m; i++)
                for (int j = 0; j < mass.n; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = mass.arr[i, j];
                }
        }

        private void findMaxValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int max, maxi = 1, maxj = 1;
            max = mass.arr[0, 0];

            for (int i = 0; i < mass.m; i++)
                for (int j = 0; j < mass.n; j++)
                {
                    if (mass.arr[i, j] > max)
                    {
                        max = mass.arr[i, j];
                        maxi = i+1;
                        maxj = j+1;
                    }
                        
                        
                }
            label5.Text = "Max value is " + max.ToString() + ", is on " + maxi.ToString() + " row and " + maxj.
                ToString() + " column.";
                
        }

        private void findMinValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int min, mini = 1, minj = 1;
            min = mass.arr[0, 0];

            for (int i = 0; i < mass.m; i++)
                for (int j = 0; j < mass.n; j++)
                {
                    if (mass.arr[i, j] < min)
                    {
                        min = mass.arr[i, j];
                        mini = i + 1;
                        minj = j + 1;
                    }


                }
            label6.Text = "Min value is " + min.ToString() + ", is on " + mini.ToString() + " row and " + minj.
                ToString() + " column.";

        }

        private void findMaxColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] sumcol = new int[mass.n];
            for (int j = 0; j < mass.n; j++)
            {
                for (int i = 0; i < mass.m; i++)
                {
                    sumcol[j] += mass.arr[i, j];
                }
            }
            int maxsum = sumcol[0];
            int numcol = 1;
            for (int i = 0; i < mass.n; i++)
            {
                if (sumcol[i] > maxsum)
                { 
                    maxsum = sumcol[i];
                    numcol = i+1;
                }
            }
            label7.Text = "Max sum values is " + maxsum.ToString() + " in " + numcol.ToString() + " column.";

        }

        private void findMaxRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[] sumrow = new int[mass.m];
            for (int i = 0; i < mass.m; i++)
            {
                for (int j = 0; j < mass.n; j++)
                {
                    sumrow[i] += mass.arr[i, j];
                }
            }
            int maxsum = sumrow[0];
            int numrow = 1;
            for (int i = 0; i < mass.m; i++)
            {
                if (sumrow[i] > maxsum)
                {
                    maxsum = sumrow[i];
                    numrow = i+1;
                }
            }
            label8.Text = "Max sum values is " + maxsum.ToString() + " in " + numrow.ToString() + " row.";

        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}