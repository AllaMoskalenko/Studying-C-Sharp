using System.IO;
/*1. Считать из текстового файла текст.
2. Создать два выходных файла: в первый записать все четные строки, во второй - нечетные;
3. Вывести на экран содержимое каждого из трех файлов и соответствующие им количества строк.
4. названия двух выходных файлов пользователь может поменять

*/
namespace HomeWork07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

        }
        string file1, file2="Text2.txt", file3="Text3.txt", str;

        private void changeFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newname2, newname3;    
            
            if (comboBox2.SelectedItem != null)
            {
                newname2 = comboBox2.SelectedItem.ToString();
                FileInfo fileInfo2 = new FileInfo(file2);
                System.IO.File.Move(fileInfo2.Name,newname2);
                label2.Text = newname2;
                file2 = newname2;
            }

            if (comboBox3.SelectedItem != null)
            {
                newname3 = comboBox3.SelectedItem.ToString();
                FileInfo fileInfo3 = new FileInfo(file3);
                System.IO.File.Move(fileInfo3.Name, newname3);
                label3.Text = newname3;
                file3 = newname3;
            }
            
            
        }

        private void clearWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void readFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            file1 = System.IO.Path.GetFullPath("Text1.txt"); //file for reading
            FileInfo fileInfo1 = new FileInfo(file1);    
            label1.Text = fileInfo1.Name;
            FileStream fileStream1 = File.OpenRead(file1);
            StreamReader reader = new StreamReader(fileStream1);
            
            //file2 = "Text2.txt";                             //first file for writing
            label2.Text = file2;
            FileStream fileStream2 = File.Create(file2);
            StreamWriter streamWriter2 = new StreamWriter(fileStream2);

            
            //file3 = "Text3.txt";                            //second file for writing
            label3.Text = file3;
            FileStream fileStream3 = File.Create(file3);
            StreamWriter streamWriter3 = new StreamWriter(fileStream3);
            //reading lines

            int c = 0;
            while (reader.Peek() >= 0)
            {
                str = reader.ReadLine();
                c++;
                richTextBox1.Text += str + "\n";
                if (c%2 == 0)
                {
                    streamWriter2.WriteLine(str);
                    richTextBox2.Text += str + "\n";
                }
                else
                {
                    streamWriter3.WriteLine(str);
                    richTextBox3.Text += str + "\n";
                }
            }
            reader.Close();
            streamWriter2.Close();
            streamWriter3.Close();


        }
    }
}
