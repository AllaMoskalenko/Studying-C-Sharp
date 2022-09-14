namespace HomeWork14
{
    public partial class Form1 : Form
    {
        Abonent[] abonents;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string f1;
            f1 = System.IO.Path.GetFullPath("Phonebook.txt");
            FileStream fs = File.OpenRead(f1);
            StreamReader sr = new StreamReader(f1);
            string line, username;
            int counter = 0, i = 0;
            
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                counter++;
            } 
            sr.Close();

            abonents = new Abonent[counter];
            string[] abon  = new string[2];
            sr = new StreamReader(f1);
            
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                abon = line.Split(" ");
                abonents[i] = new Abonent(abon[0], abon[1]);
                i++;
            }
            sr.Close();

            username = textBox1.Text;
            label2.Text = "Номер телефону: "+ Abonent.FindName(abonents, username);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}