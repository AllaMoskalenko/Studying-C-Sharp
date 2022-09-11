namespace HomeWork11
    /*Написать программу, выполняющую:
1. ввод с клавиатуры n студентов (если есть желание, то можно сделать ввод из файла, чтобы по 100 раз не вбивать вручную);
2. вывод на экран студентов, средний бал которых превышает 4 - "успешные" студенты;
3. отсортировать список "успешных" студентов по возрастанию среднего бала
    */
{
    public partial class Form1 : Form
    {
        Stud[] students;
        Stud[] successful;
        public Form1()
        {
            InitializeComponent();

            richTextBox1.Clear();
            comboBox1.Refresh();

            string f1;
            f1 = System.IO.Path.GetFullPath("Students.txt");
            FileStream fs = File.OpenRead(f1);
            StreamReader sr = new StreamReader(f1);

            
            int counter = 0;
            string line;
            
            
            //count students
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                counter++;
            }
            sr.Close();
            string[] studInfo;
            string[] studName = new string[3];
            string gr;
            int[] points = new int[4];
            students = new Stud[counter];
            int c = 0, fl = 0;
            sr = new StreamReader(f1);
            //create array of students and full it
            while (sr.Peek() != -1)
            {                               
                line =sr.ReadLine();
                studInfo = line.Split(" ");
                for (int i = 0; i < 3; i++)
                {
                    studName[i] = studInfo[i];
                }
                gr = studInfo[3];
                for (int i = 0; i < 4; i++)
                {
                    points[i] = Convert.ToInt32(studInfo[i + 4]);
                } 

                students[c] = new Stud(studName, gr,points);
                c++;
                if (comboBox1.Items.Count == 0)
                {
                    comboBox1.Items.Add(gr);
                }
                else
                {
                    for (int j = 0; j < comboBox1.Items.Count; j++)
                    {
                        if (comboBox1.Items[j].ToString() == gr)
                        { 
                            fl = 0;
                            break;
                        }

                        else
                            fl = 1;
                    }
                }
                if (fl == 1)
                {
                    comboBox1.Items.Add(gr);
                    fl = 0;
                }
            }
            sr.Close ();
            comboBox1.Items.Add("All students");


        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (comboBox1.SelectedIndex < 0 || comboBox1.Text == "All students")
            {
                for (int i = 0; i < students.Length; i++ )
                {
                    richTextBox1.Text += students[i].name[0] + " " + students[i].Avrg().ToString() + " \n";
                }
            }
            if (comboBox1.SelectedIndex >= 0)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    if (comboBox1.Text == students[i].group)
                    {
                        richTextBox1.Text += students[i].name[0] + " " + students[i].Avrg().ToString() + " \n";
                    }
                }
            }

        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void successfulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            int counter = 0;
            int num = 0;
            for (int j = 0; j < students.Length; j++)
            {
                if (students[j].Avrg() >= 4) counter++;
            }
            successful = new Stud[counter];
            for (int j = 0; j < students.Length; j++)
            {
                if (students[j].Avrg() >=4)
                {
                    successful[num] = students[j];
                    num++;
                }
            }
            richTextBox1.Text = "";
            if (comboBox1.SelectedIndex < 0 || comboBox1.Text == "All students")
            {
                for (int i = 0; i < successful.Length; i++)
                {
                    richTextBox1.Text += successful[i].name[0] + " " + successful[i].Avrg().ToString() + " \n";
                }
            }
            if (comboBox1.SelectedIndex >= 0)
            {
                for (int i = 0; i < successful.Length; i++)
                {
                    if (comboBox1.Text == successful[i].group)
                    {
                        richTextBox1.Text += successful[i].name[0] + " " + successful[i].Avrg().ToString() + " \n";
                    }
                }
            }
        }

        private void reitingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stud[] sstud = new Stud[successful.Length];
            for (int i = 0; i < sstud.Length; i++)
            {
                sstud[i] = successful[i];
            }
                
            Stud maxStud = new Stud();
            int jmax = 0;
            for (int j = 0; j < sstud.Length; j++)
            {
                maxStud = sstud[j];
                jmax = j;
                for (int i = j+1; i < sstud.Length; i++)
                {
                    if (sstud[i].Avrg() > maxStud.Avrg())
                    {
                        maxStud = sstud[i];
                        jmax = i;
                    }
                    if (sstud[j].Avrg() < maxStud.Avrg())
                    {
                        sstud[jmax] = sstud[j]; 
                        sstud[j] = maxStud;
                    }
                }
            }

            richTextBox1.Text = "";
            if (comboBox1.SelectedIndex < 0 || comboBox1.Text == "All students")
            {
                for (int i = 0; i < sstud.Length; i++)
                {
                    richTextBox1.Text += sstud[i].name[0] + " " + sstud[i].Avrg().ToString() + " \n";
                }
            }
            if (comboBox1.SelectedIndex >= 0)
            {
                for (int i = 0; i < sstud.Length; i++)
                {
                    if (comboBox1.Text == sstud[i].group)
                    {
                        richTextBox1.Text += sstud[i].name[0] + " " + sstud[i].Avrg().ToString() + " \n";
                    }
                }
            }
        }
    }
}
