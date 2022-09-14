namespace HomeWork14
    /*
    Задача:
0. Считать файл.
1. В textBox вводится имя абонента и по нажатию на кнопку надо вывести номер телефона этого абонента.
2. В случае, если абонент не был найден, то вывести об этом на экран.
3. Если абонентов с одинаковым именем несколько - вывести первый найденный.
    */
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
            label2.Text = "Íîìåð òåëåôîíó: "+ Abonent.FindName(abonents, username);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
