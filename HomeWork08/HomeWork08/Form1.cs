namespace HomeWork08
    /*
    Есть файл с особо структурированным текстом:
каждая строка представляет собой два целых числа, записанные через пробел
//Например:
//10 10
//23 -50
//-10 70
каждая пара чисел в строке - это координаты точек.
Задача:
1. Считать последовательность координат из файла и показать его содержимое (текст) на экран;
2. По этим координатам построить ломаную линию (как в HomeWork03);
3. Найти самый длинный отрезок из построенных и выделить его цветом.
4. Имя файла заранее известно (пользователь его не задает)
    */
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

        private void button1_Click(object sender, EventArgs e)
        {
            string ourfile, f1, str;
            string[] coord;
            int c = 0;
            
            pictureBox1.Refresh();
            dataGridView1.Rows.Clear();
            
            ourfile = "Coordinates.txt";
            f1 = System.IO.Path.GetFullPath(ourfile);
            FileStream fs = File.OpenRead(f1);
            StreamReader sr = new StreamReader(f1);

            while (sr.Peek() != -1) 
            {
                str = sr.ReadLine();
                coord = str.Split(" ");
                dataGridView1.Rows.Add(Convert.ToInt32(coord[0]), Convert.ToInt32(coord[1]));
                c++;
            }
            sr.Close();
            fs.Close();
            
            //axes
            int x0 = 0, y0 = 0, x, y;
            x = pictureBox1.Width / 2;
            y = pictureBox1.Height / 2;
            Graphics graphics = pictureBox1.CreateGraphics();
            Pen pen1 = new Pen(Color.Black, 1);
            graphics.DrawLine(pen1, x0, y, 2*x, y);
            graphics.DrawLine(pen1, x, y0, x, 2*y);

            //lines
            Pen pen2 = new Pen(Color.Blue, 2);
            for (int i = 0; i < c-1; i++)
            {
                graphics.DrawLine(pen2, Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) + x,
                                        y - Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value),
                                        Convert.ToInt32(dataGridView1.Rows[i + 1].Cells[0].Value) + x,
                                        y - Convert.ToInt32(dataGridView1.Rows[i + 1].Cells[1].Value) ) ;
            }
            
            //find length of lines
            double[] len = new double[c-1];
            for (int i = 0; i < c - 1; i++)
            {
                len[i] = Math.Sqrt(Math.Pow((Convert.ToInt32(dataGridView1.Rows[i + 1].Cells[0].Value) - Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value)), 2) 
                                 + Math.Pow((Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value) - Convert.ToInt32(dataGridView1.Rows[i + 1].Cells[1].Value)), 2));            
            }
            double maxlen = len[0];
            int ind = 0;
            for (int i = 1; i < len.Length; i++)
            {
                if(len[i] > maxlen) 
                { 
                    maxlen = len[i]; 
                    ind = i;
                }                  
            }
            
            //drew max line another color
            Pen pen3 = new Pen(Color.Aquamarine, 3);
            graphics.DrawLine(pen3, Convert.ToInt32(dataGridView1.Rows[ind].Cells[0].Value) + x,
                                    y - Convert.ToInt32(dataGridView1.Rows[ind].Cells[1].Value),
                                    Convert.ToInt32(dataGridView1.Rows[ind + 1].Cells[0].Value) + x,
                                    y - Convert.ToInt32(dataGridView1.Rows[ind + 1].Cells[1].Value));
        }
    }
}
