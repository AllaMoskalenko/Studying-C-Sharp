using System.Collections;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

namespace HomeWork19
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        //Point p1, p2;
        public Graph graph;
        int v1, v2;
        Color colorUp = Color.LightGray;
        Color colorDown = Color.LightSlateGray;
        bool mouseDown, mouseUp;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            graph = new Graph();
            label1.Text = "To start building a graph, click the \"Add vertex\" button and place it in a free space";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void button1_Click(object sender, EventArgs e)   //button for adding vertexes
        {
            if (button1.BackColor == colorDown)
            {
                button1.BackColor = colorUp;
                label1.Text = "Double click the vertex to change name";
            }
            else
            {
                button1.BackColor = colorDown;
                button2.BackColor = colorUp;
                button3.BackColor = colorUp;
                button4.BackColor = colorUp;
                label1.Text = "Click on empty space in order to place the vertex";
            }
        }

        private void button2_Click(object sender, EventArgs e)   //button for adding edges
        {
            if (button2.BackColor == colorDown)
            {
                button2.BackColor = colorUp;
                label1.Text = "";
            }
            else
            {
                button2.BackColor = colorDown;
                button1.BackColor = colorUp;                
                button3.BackColor = colorUp;
                button4.BackColor = colorUp;
                label1.Text = "Move from vertex to vertex in order to make or change weight of the edge";
            }
        }

        private void button3_Click(object sender, EventArgs e)  //button for deleting vertexes
        {
            if (button3.BackColor == colorDown)
            {
                button3.BackColor = colorUp;
                label1.Text = "";
            }
            else
            {
                button3.BackColor = colorDown;
                button1.BackColor = colorUp;
                button2.BackColor = colorUp;                
                button4.BackColor = colorUp;
                label1.Text = "Click the vertex you want to remove";
            }
        }

        private void button4_Click(object sender, EventArgs e)   //button for deleting edges
        {
            if (button4.BackColor == colorDown)
            {
                button4.BackColor = colorUp;
                label1.Text = "";
            }
            else
            {
                button4.BackColor = colorDown;
                button1.BackColor = colorUp;
                button2.BackColor = colorUp;
                button3.BackColor = colorUp;
                label1.Text = "Move from vertex to vertex to delete the edge";
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (button1.BackColor == colorDown)
            {
                
                graph.CreateVertex(new Point(e.X, e.Y));
                g.Clear(Color.White);
                graph.DrawGraph(g);
                pictureBox1.Image = bmp;
            }
            if (button3.BackColor == colorDown)
            {
                if (graph.index_of_vertex(e.Location) >= 0)
                {
                    graph.DeleteVertex(graph.index_of_vertex(e.Location));
                }
                g.Clear(Color.White);
                graph.DrawGraph(g);
                pictureBox1.Image = bmp;
            }
        }
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            mouseUp = false;
            if (button2.BackColor == colorDown || button4.BackColor == colorDown)
            {
                v1 = graph.index_of_vertex(e.Location);                
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)  //double click for set name of vertex
        {
            int t = graph.index_of_vertex(e.Location);
            if (t >= 0)
            {
                graph.vertexes[t].name =Microsoft.VisualBasic.Interaction.InputBox("Input name:");
            }
            g.Clear(Color.White);
            graph.DrawGraph(g);
            pictureBox1.Image = bmp;
        }

        private void matrixToolStripMenuItem_Click(object sender, EventArgs e)  //Adjacency Matrix
        {
            Matrix_Show adj_matrix = new Matrix_Show();
            adj_matrix.t_graph = graph;
            adj_matrix.matrix = graph.Matrix_Adjacency();
            adj_matrix.flag = 1; 
            adj_matrix.ShowDialog();            
        }

        private void matrixIncidenceyToolStripMenuItem_Click(object sender, EventArgs e)   //Incidencey matrix
        {
            Matrix_Show inc_matrix = new Matrix_Show();
            inc_matrix.t_graph = graph;
            inc_matrix.matrix = graph.Matrix_Incidencey();
            inc_matrix.flag = 2;
            inc_matrix.ShowDialog();            
        }

        private void listAdjacencyToolStripMenuItem_Click(object sender, EventArgs e)  //Adjacency list
        {
            Matrix_Show list = new Matrix_Show();
            list.t_graph = graph;
            list.list_adj = graph.List_Adjacency();
            list.flag = 3;
            list.ShowDialog();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)   //open file
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Choose file";
            openFile.InitialDirectory = Application.StartupPath;
            openFile.Filter = "Graph files (*.graphHW19)|*.graphHW19";
            openFile.Multiselect = false; 
            openFile.CheckFileExists = true; 
            openFile.CheckPathExists = true;
            label4.Text = "Search result:";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";


            if (openFile.ShowDialog() == DialogResult.OK) 
            {
                string filename = openFile.FileName;   
                FileStream fs = File.OpenRead(filename);
                StreamReader sr = new StreamReader(fs);
                
                string line;
                List <string> list = new List<string>();
                while (sr.Peek() != -1)
                {
                    line = sr.ReadLine(); 
                    list.Add(line);
                }
                graph = new Graph(list);
                g.Clear(Color.White);
                graph.DrawGraph(g);
                pictureBox1.Image = bmp;
                sr.Close();
                fs.Close();
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)  //save file
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "graphHW19";
            saveFile.AddExtension = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFile.FileName;
                System.IO.File.WriteAllLines(fileName, graph.Save_Graph());
                MessageBox.Show("File successfully saved");
            }
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)   //clear all
        {
            label4.Text = "Search result:";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            graph = new Graph();
            g.Clear(Color.White);
            graph.DrawGraph(g);
            pictureBox1.Image = bmp;
        }

        private void allMatrixToolStripMenuItem_Click(object sender, EventArgs e)  // all matrix in 1 window
        { 
            Form2 form2 = new Form2();
            form2.all_matrixes = graph.All_Matrixes();
            form2.ShowDialog();
            
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            panel1.BackColor = Color.WhiteSmoke;
            string []file = (string[])e.Data.GetData(DataFormats.FileDrop);
            //File.Open(file[0], FileMode.Open, FileAccess.Read);
            label2.Text = "Drag file here";
            FileStream fs = File.OpenRead(file[0]);
            StreamReader sr = new StreamReader(fs);

            string line;
            List<string> list = new List<string>();
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                list.Add(line);
            }
            sr.Close();
            fs.Close();
            label4.Text = "Search result:";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            graph = new Graph(list);
            g.Clear(Color.White);
            graph.DrawGraph(g);
            pictureBox1.Image = bmp;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                label2.Text = "Leave mouse";
                e.Effect = DragDropEffects.Copy;
                panel1.BackColor = Color.Red;
            }
        }

        private void panel1_DragLeave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.WhiteSmoke;
            label2.Text = "Drag file here";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.White, 3);
            e.Graphics.DrawRectangle(pen, 0, 0, panel1.Width - 3, panel1.Height - 3);
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);            
            g.Clear(Color.White);
            graph.DrawGraph(g);
            pictureBox1.Image = bmp;
        }

        private void button5_Click(object sender, EventArgs e)          //Search in width
        {
            string name = textBox1.Text;
            List <string> widsear = new List<string>();
            List <int> wid = new List<int>();
            int num = graph.vertexes.Count;
            
            for (int i = 0; i < num; i++)
            {
                if (graph.vertexes[i].name == name)
                {
                    wid.Add(i);
                }
            }
            
            if (wid.Count == 0)
            {
                MessageBox.Show("Sorry, vertex not found!");                
            }

            int[,] adj = new int[num, num];
            adj = graph.Matrix_Adjacency();
                        
            for (int i=0; i < wid.Count; i++)
            {
                for (int j = wid[i]; j < wid[i]+1; j++)
                {
                    for (int k = 0; k < num; k++)
                    {
                        if (adj[j,k] != 0)
                        {
                            if (wid.Contains(k) == false)
                                wid.Add(k);
                        }
                    }
                }
            }
            for (int i = 0; i < wid.Count; i++)
            {
                widsear.Add(graph.vertexes[wid[i]].name);
            }
            StringBuilder sb = new StringBuilder();
            for (int i= 0; i< widsear.Count; i++)
            {
                sb.Append(widsear[i] + " ");
            }
            label4.Text = "Search result: " + sb.ToString();
        }
        private void button6_Click(object sender, EventArgs e)    //Search in depth
        {
            string name = textBox2.Text;
            List<string> depthsear = new List<string>();
            List<int> dep = new List<int>();
            int num = graph.vertexes.Count;

            for (int i = 0; i < num; i++)
            {
                if (graph.vertexes[i].name == name)
                {
                    dep.Add(i);
                }
            }

            if (dep.Count == 0)
            {
                MessageBox.Show("Sorry, vertex not found!");
            }
            int[,] adj = new int[num, num];
            adj = graph.Matrix_Adjacency();

            Stack<int> stk = new Stack<int>();

            for (int j = dep[0]; ;)
            {
                for (int k = num - 1; k >= 0; k--)
                {
                    if (adj[j, k] != 0)
                    {
                        if (dep.Contains(k) == false)
                        {
                            if (stk.Contains(k) == false)
                                stk.Push(k);
                        }
                    }
                }
                if (stk.Count != 0)
                {
                    j = stk.Pop();
                    dep.Add(j);
                } else break;
            }            

            for (int i = 0; i < dep.Count; i++)
            {
                depthsear.Add(graph.vertexes[dep[i]].name);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < depthsear.Count; i++)
            {
                sb.Append(depthsear[i] + " ");
            }
            label4.Text = "Search result: " + sb.ToString();

        }

        private void button7_Click(object sender, EventArgs e)   //Dijkstra's algorithm
        {
            int num = graph.vertexes.Count;
            bool[] S = new bool[num];        //true - if vertex seen
            int[] Dist = new int[num];       // shortcuts
            int[] C = new int[num];          //path
            int[,] adj = new int[num, num];
            adj = graph.Matrix_Adjacency();
            string name1 = textBox3.Text;
            string name2 = textBox4.Text;

            int first=-1, last =-1;
            
            for (int i = 0; i < num; i++)
            {
                if (graph.vertexes[i].name == name1)
                {
                    first = i;
                }
            }
            for (int i = 0; i < num; i++)
            {
                if (graph.vertexes[i].name == name2)
                {
                    last = i;
                }
            }
            if (first == -1 || last == -1)
            {
                MessageBox.Show("Sorry, vertex not found!");
            }
            Stack<int> stack = new Stack<int>();
            for (int i =0; i <num; i++)
            {
                S[i] = false;
                C[i] = first;
                Dist[i] = int.MaxValue;
            }
            Dist[first] = 0;
            stack.Push(first);
            int j = first;
            while (stack.Count > 0)
            {
                j = stack.Pop();
                for (int i = 0; i<num; i++)
                {
                    if (adj[j,i] != 0)
                    {
                        if (Dist[i] > adj[j, i] + Dist[j])
                        {
                            Dist[i] = adj[j, i] + Dist[j];
                            C[i] = j;
                            if (S[i] == false) stack.Push(i);
                        }
                    }
                }
                S[j] = true;
            }
            int k = last;
            Stack<int> path = new Stack<int>();
            path.Push(last);
            
            while (C[k] != first)
            {
                k = C[k];
                path.Push(k);
            }
            path.Push(first);

            label4.Text = "Search result: ";
            while (path.Count > 0)
            {
                label4.Text += path.Pop().ToString() + " ";
            }
            label4.Text += "\n Path weight: " + Dist[last].ToString();

        }

        private void button8_Click(object sender, EventArgs e)   //Colorize graph
        {
            graph.Colorize();
            g.Clear(Color.White);
            graph.DrawGraph(g);
            pictureBox1.Image = bmp;

        }

        private void button9_Click(object sender, EventArgs e)   //Clear color
        {
            for (int i = 0; i < graph.vertexes.Count; i++)
            {
                graph.vertexes[i].colorok = Color.White;
            }
            g.Clear(Color.White);
            graph.DrawGraph(g);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)   // moving vertexes
        {
            Point p = new Point(e.X, e.Y);
            if (mouseDown && button2.BackColor == colorUp && button4.BackColor == colorUp)
            {
                if (graph.index_of_vertex(p) >= 0)
                {
                    graph.vertexes[graph.index_of_vertex(p)].point = new Point(p.X, p.Y);
                    g.Clear(Color.White);
                    graph.DrawGraph(g);
                    pictureBox1.Image = bmp;
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            mouseUp = true;
            if (button2.BackColor == colorDown)
            {
                v2 = graph.index_of_vertex(e.Location);
                if (v1 >= 0 && v2 >= 0)
                {
                    string text = Microsoft.VisualBasic.Interaction.InputBox("Input weight of edge:");
                    int edgeWeight = 1;
                    int.TryParse(text, out edgeWeight);
                    if (edgeWeight <= 0) edgeWeight = 1;                    
                    graph.CreateEdge(v1, v2, edgeWeight);
                }
                g.Clear(Color.White);
                graph.DrawGraph(g);
                pictureBox1.Image = bmp;
            }
            if (button4.BackColor == colorDown) {
                v2 = graph.index_of_vertex(e.Location);
                if (v1 >= 0 && v2 >= 0) graph.DeleteEdge(v1, v2);
                g.Clear(Color.White);
                graph.DrawGraph(g);
                pictureBox1.Image = bmp;
            }
        }
    }
}