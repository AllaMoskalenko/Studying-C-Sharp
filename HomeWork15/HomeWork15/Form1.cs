namespace HomeWork15
{
    public partial class Form1 : Form
    {
        List <Rocket> rockets = new List<Rocket>();
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showRocketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string f1 = System.IO.Path.GetFullPath("Rockets.txt");
            if (File.Exists(f1))
            {

                FileStream fs = File.OpenRead(f1);
                StreamReader sr = new StreamReader(fs);
                string line;
                string[] rock;
                rockets.Clear();
                while (sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    rock = line.Split();
                    rockets.Add(new Rocket(rock));

                    comboBox1.Items.Add(rock[0]);
                }
                sr.Close();
            }
            else
            {
                label1.Text = "File not find!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                richTextBox1.Text = "Chose the rocket!";
            }
            else
            {
                richTextBox1.Text = rockets[comboBox1.SelectedIndex].Info();
            }            
            
        }

        private void showAllRocketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Visible = true;
            listBox1.Items.Add("Name:          \t Cost:  \t     \tWeight:");
            for (int i = 0; i < rockets.Count; i++)
            {
                listBox1.Items.Add(rockets[i].Name + "          \t " + rockets[i].CountCost() + " c.u. \t " + rockets[i].CommonWeight()+ "t ");
            }
        }
        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Visible = true;
            listBox1.Items.Add("Name:          \t Cost:  \t     \tWeight:");
            List<Rocket> temprockets = new List<Rocket>();  //rockets;
            foreach(Rocket r in rockets)
            {
                temprockets.Add(r);
            }
            temprockets.Sort(delegate (Rocket r1, Rocket r2)
            {
                return r1.Name.CompareTo(r2.Name);
            });
            for (int i = 0; i < temprockets.Count; i++)
            {
                listBox1.Items.Add(temprockets[i].Name + "          \t " + temprockets[i].CountCost() + " c.u. \t " + temprockets[i].CommonWeight() + "t ");
            }
        }

        private void costToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Visible = true;
            listBox1.Items.Add("Name:          \t Cost:  \t     \tWeight:");
            List<Rocket> temprockets = new List<Rocket>();  //rockets;
            foreach (Rocket r in rockets)
            {
                temprockets.Add(r);
            }
            temprockets.Sort(delegate (Rocket r1, Rocket r2)
            {
                if (r1.CountCost() > r2.CountCost()) return 1;
                else if (r1.CountCost() < r2.CountCost()) return -1;
                else return 0;
            });
            for (int i = 0; i < temprockets.Count; i++)
            {
                listBox1.Items.Add(temprockets[i].Name + "          \t " + temprockets[i].CountCost() + " c.u. \t " + temprockets[i].CommonWeight() + "t ");
            }
        }

        private void weightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Visible = true;
            listBox1.Items.Add("Name:          \t Cost:  \t     \tWeight:");
            List<Rocket> temprockets = new List<Rocket>();  //rockets;
            foreach (Rocket r in rockets)
            {
                temprockets.Add(r);
            }
            temprockets.Sort(delegate (Rocket r1, Rocket r2)
            {
                if (r1.CommonWeight() > r2.CommonWeight()) return -1;
                else if (r1.CommonWeight() < r2.CommonWeight()) return 1;
                else return 0;
            });
            for (int i = 0; i < temprockets.Count; i++)
            {
                listBox1.Items.Add(temprockets[i].Name + "          \t " + temprockets[i].CountCost() + " c.u. \t " + temprockets[i].CommonWeight() + "t ");
            }
        }

        private void addNewRosketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            //newForm.trocket = rockets[2];
            newForm.ShowDialog();
            if (newForm.trocket != null)
            {
                rockets.Add(newForm.trocket);
                comboBox1.Items.Add(newForm.trocket.Name);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm = new Form2();
            newForm.trocket = rockets[comboBox1.SelectedIndex];
            newForm.ShowDialog();
            rockets.Remove(rockets[comboBox1.SelectedIndex]);
            rockets.Insert(comboBox1.SelectedIndex, newForm.trocket);
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            for (int i = 0; i < rockets.Count; i++)
            {
                comboBox1.Items.Add(rockets[i].Name);
            }
        }

        private void saveAllChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] writeRock = new string[rockets.Count];
            for (int i = 0; i < rockets.Count; i++)
            {
                writeRock[i] = rockets[i].Name + " ";
                if (rockets[i].body.ToString() == "SmallBody") writeRock[i] += "SB ";
                if (rockets[i].body.ToString() == "MiddleBody") writeRock[i] += "MB ";
                if (rockets[i].body.ToString() == "BigBody") writeRock[i] += "BB ";
                writeRock[i] += rockets[i].NumOfStages.ToString() + " ";
                for (int j = 0; j < rockets[i].NumOfStages; j++)
                {
                    if (rockets[i].engine[j].ToString() == "ReactiveEngine") writeRock[i] += "RE ";
                    if (rockets[i].engine[j].ToString() == "DetonationEngine") writeRock[i] += "DE ";
                    if (rockets[i].engine[j].ToString() == "PlasmaEngine") writeRock[i] += "PE ";
                }
                for (int j = 0; j < rockets[i].NumOfStages; j++)
                {
                    if (rockets[i].fuelReservoir[j].ToString() == "SmallReservoir") writeRock[i] += "SR ";
                    if (rockets[i].fuelReservoir[j].ToString() == "MiddleReservoir") writeRock[i] += "MR ";
                    if (rockets[i].fuelReservoir[j].ToString() == "BigReservoir") writeRock[i] += "BR ";
                }
            }

            string path = System.IO.Path.GetFullPath("Rockets.txt");
            FileStream fs = File.OpenWrite(path);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < rockets.Count; i++)
            {
                sw.WriteLine(writeRock[i]);
            }
            sw.Close();
            fs.Close();
        }
    }
}