namespace HomeWork09
    /*
    Задача:
1. Считать из файла информацию о звездной системе.
2. Предоставить возможность пользователю отдельно выбрать любой объект системы и посмотреть о нем информацию. 
(подразумеваю, что после прочтения файла образуется список объектов, из которых и можно выбирать)
3. Посчитать количество звезд, планет и спутников в системе.
4. вывести название планеты с наибольшим количеством спутников.
    */
{
    public partial class Form1 : Form
    {
        SpaceObjects[] space;
        public Form1()
        {
            InitializeComponent();
            
            string f1;
            f1 = System.IO.Path.GetFullPath("SolarSystem.txt");
            FileStream fs = File.OpenRead(f1);
            StreamReader sr = new StreamReader(f1);
            
            //count objects in file
            string line;
            string[] value1;
            int counter = 0, number;
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                value1 = line.Split(" ");
                if (value1.Length == 1 || value1.Length > 2)
                {
                    counter = counter + value1.Length;
                }
                else
                {
                    if (int.TryParse(value1[1], out number)) 
                    {
                        counter++;
                    }
                    else counter = counter + 2;
                }
            }                   
            sr.Close();
            
            //create objects
            space = new SpaceObjects[counter];
            sr = new StreamReader(f1);
            int i = 0;
            int starscount = 0, planetscount = 0, mooncount = 0, maxmoonplanet = -1;
            string maxmoonplanetname = "";
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                value1 = line.Split(" ");
                if (value1.Length == 1)
                {
                    space[i] = new Planet(value1[0]);
                    comboBox1.Items.Add(space[i].name);
                    planetscount++;
                    if (maxmoonplanet < 0)
                    {
                        maxmoonplanet = 0;
                    }
                }
                else if (value1.Length > 2)
                {
                    space[i] = new Planet(value1);
                    comboBox1.Items.Add(space[i].name);
                    i++;
                    planetscount++;
                    if (maxmoonplanet < value1.Length - 1)
                    {
                        maxmoonplanetname = value1[0];
                        maxmoonplanet = value1.Length - 1;
                    }
                    for (int j = 1; j < value1.Length; j++)
                    {
                        space[i] = new Moon(value1[j], value1[0]);
                        comboBox1.Items.Add(space[i].name);
                        i++;
                        mooncount++;
                    }
                    i--;
                }
                else if (int.TryParse(value1[1], out number))
                {
                    space[i] = new Star(value1[0], number);
                    comboBox1.Items.Add(space[i].name);
                    starscount++;
                }
                else
                {
                    space[i] = new Planet(value1);
                    comboBox1.Items.Add(space[i].name);
                    i++;
                    planetscount++;
                    if (maxmoonplanet < 1)
                    {
                        maxmoonplanet = 1;
                        maxmoonplanetname = value1[0];
                    }
                    space[i] = new Moon(value1[1], value1[0]);
                    comboBox1.Items.Add(space[i].name);
                    mooncount++;                    
                }
                i++;
                
            }
            sr.Close();

            label1.Text = "There are: " + starscount + " star, " + planetscount + " planets, " + mooncount + " moons in system.";
            if (maxmoonplanet < 0)
            {
                label1.Text += "\n There are no planets in this system.";
            }
            else if (maxmoonplanet == 0)
            {
                label1.Text += "\n The planets don't have moons in this system.";
            }
            else
            {
                label1.Text += "\n The " + maxmoonplanetname + " has " + maxmoonplanet + " moons. It is max value.";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nomer;
            nomer = comboBox1.SelectedIndex;
            richTextBox1.Text = space[nomer].About();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
