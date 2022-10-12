using System.Text;

namespace HomeWork18
{

    public partial class Form1 : Form
    {
        public int clickCounter = 1;
        public int[,] game;
        public int c, level , player;
        public int[] stat = new int[9];
        public void startGame()
        {
            clickCounter = 1;

            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "Player turn: X";

            game = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    game[i, j] = 0;
                }
            }
        }

        public void pcOStep()    // Hod Kompa "O"
        {
            Random random = new Random();
            while (true)
            {   
                if (continueGame() == 0 && clickCounter % 2 == 0)
                {
                    int i = random.Next(0, 3);
                    int j = random.Next(0, 3);

                    if (game[i, j] == 0)
                    {
                        game[i, j] = -1;
                        clickCounter++;
                        if (i == 0 && j == 0)
                        {
                            label1.Text = "O";
                        }
                        else if (i == 0 && j == 1)
                        {
                            label2.Text = "O";
                        }
                        else if (i == 0 && j == 2)
                        {
                            label3.Text = "O";
                        }
                        else if (i == 1 && j == 0)
                        {
                            label4.Text = "O";
                        }
                        else if (i == 1 && j == 1)
                        {
                            label5.Text = "O";
                        }
                        else if (i == 1 && j == 2)
                        {
                            label6.Text = "O";
                        }
                        else if (i == 2 && j == 0)
                        {
                            label7.Text = "O";
                        }
                        else if (i == 2 && j == 1)
                        {
                            label8.Text = "O";
                        }
                        else if (i == 2 && j == 2)
                        {
                            label9.Text = "O";
                        }
                        break;
                    }  
                } 
                else break;
            }
        }
        public void pcXStep ()   // Hod kompa "X"
        {
            Random random = new Random();
            while (true)
            {
                if (continueGame() == 0 && clickCounter % 2 == 1)
                {
                    int i = random.Next(0, 3);
                    int j = random.Next(0, 3);

                    if (game[i, j] == 0)
                    {
                        game[i, j] = 1;
                        clickCounter++;
                        if (i == 0 && j == 0)
                        {
                            label1.Text = "X";
                        }
                        else if (i == 0 && j == 1)
                        {
                            label2.Text = "X";
                        }
                        else if (i == 0 && j == 2)
                        {
                            label3.Text = "X";
                        }
                        else if (i == 1 && j == 0)
                        {
                            label4.Text = "X";
                        }
                        else if (i == 1 && j == 1)
                        {
                            label5.Text = "X";
                        }
                        else if (i == 1 && j == 2)
                        {
                            label6.Text = "X";
                        }
                        else if (i == 2 && j == 0)
                        {
                            label7.Text = "X";
                        }
                        else if (i == 2 && j == 1)
                        {
                            label8.Text = "X";
                        }
                        else if (i == 2 && j == 2)
                        {
                            label9.Text = "X";
                        }
                        break;
                    }
                }
                else break;
            }
        }  
        public int continueGame()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (game[i, j] == 0) return 0;  //igra prodolgaetsya
                }
            }
            return 2; // vse polya zanyaty, konec igry
        }

        public int Win()  //1 = "X", -1 = "O"
        {
            if (game[0,0] == game[0,1] && game[0,1] == game[0,2])
            {
                if (game[0,0] == 1)
                {
                    label1.ForeColor = Color.Red;
                    label2.ForeColor = Color.Red;
                    label3.ForeColor = Color.Red;
                    return 1;   //pobedil X
                } else 
                    if (game[0,0] == -1)
                {
                    label1.ForeColor = Color.Red;
                    label2.ForeColor = Color.Red;
                    label3.ForeColor = Color.Red;
                    return -1;  //pobedil O
                } 
            }
            if (game[0, 0] == game[1, 0] && game[0, 0] == game[2, 0])
            {
                if (game[0, 0] == 1)
                {
                    label1.ForeColor = Color.Red;
                    label4.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[0, 0] == -1)
                {
                    label1.ForeColor = Color.Red;
                    label4.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[0, 0] == game[1, 1] && game[1, 1] == game[2, 2])
            {
                if (game[0, 0] == 1)
                {
                    label1.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[0, 0] == -1)
                {
                    label1.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[0, 1] == game[1, 1] && game[1, 1] == game[2, 1])
            {
                if (game[0, 1] == 1)
                {
                    label2.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[0, 1] == -1)
                {
                    label2.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[0, 2] == game[1, 1] && game[1, 1] == game[2, 0])
            {
                if (game[0, 2] == 1)
                {
                    label3.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[0, 2] == -1)
                {
                    label3.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[0, 2] == game[1, 2] && game[1, 2] == game[2, 2])
            {
                if (game[0, 2] == 1)
                {
                    label3.ForeColor = Color.Red;
                    label6.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red; 
                    return 1;
                }
                else
                    if (game[0, 2] == -1)
                {
                    label3.ForeColor = Color.Red;
                    label6.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[1, 0] == game[1, 1] && game[1, 1] == game[1, 2])
            {
                if (game[1, 0] == 1)
                {
                    label4.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label6.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[1, 0] == -1)
                {
                    label4.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label6.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[2, 0] == game[2, 1] && game[2, 1] == game[2, 2])
            {
                if (game[2, 0] == 1)
                {
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[2, 0] == -1)
                {
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return -1;
                }
            }
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (game[i, j] == 0) return 0;  //igra prodolgaetsya
                }
            }
            return 2;  // nichiya!
        }
        public int Win(int[,] game)  //1 = "X", -1 = "O"
        {
            if (game[0, 0] == game[0, 1] && game[0, 1] == game[0, 2])
            {
                if (game[0, 0] == 1)
                {
                    label1.ForeColor = Color.Red;
                    label2.ForeColor = Color.Red;
                    label3.ForeColor = Color.Red;
                    return 1;   //pobedil X
                }
                else
                    if (game[0, 0] == -1)
                {
                    label1.ForeColor = Color.Red;
                    label2.ForeColor = Color.Red;
                    label3.ForeColor = Color.Red;
                    return -1;  //pobedil O
                }
            }
            if (game[0, 0] == game[1, 0] && game[0, 0] == game[2, 0])
            {
                if (game[0, 0] == 1)
                {
                    label1.ForeColor = Color.Red;
                    label4.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[0, 0] == -1)
                {
                    label1.ForeColor = Color.Red;
                    label4.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[0, 0] == game[1, 1] && game[1, 1] == game[2, 2])
            {
                if (game[0, 0] == 1)
                {
                    label1.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[0, 0] == -1)
                {
                    label1.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[0, 1] == game[1, 1] && game[1, 1] == game[2, 1])
            {
                if (game[0, 1] == 1)
                {
                    label2.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[0, 1] == -1)
                {
                    label2.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[0, 2] == game[1, 1] && game[1, 1] == game[2, 0])
            {
                if (game[0, 2] == 1)
                {
                    label3.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[0, 2] == -1)
                {
                    label3.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label7.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[0, 2] == game[1, 2] && game[1, 2] == game[2, 2])
            {
                if (game[0, 2] == 1)
                {
                    label3.ForeColor = Color.Red;
                    label6.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[0, 2] == -1)
                {
                    label3.ForeColor = Color.Red;
                    label6.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[1, 0] == game[1, 1] && game[1, 1] == game[1, 2])
            {
                if (game[1, 0] == 1)
                {
                    label4.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label6.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[1, 0] == -1)
                {
                    label4.ForeColor = Color.Red;
                    label5.ForeColor = Color.Red;
                    label6.ForeColor = Color.Red;
                    return -1;
                }
            }
            if (game[2, 0] == game[2, 1] && game[2, 1] == game[2, 2])
            {
                if (game[2, 0] == 1)
                {
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return 1;
                }
                else
                    if (game[2, 0] == -1)
                {
                    label7.ForeColor = Color.Red;
                    label8.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    return -1;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (game[i, j] == 0) return 0;  //igra prodolgaetsya
                }
            }
            return 2;  // nichiya!
        }
        int score(int[,] game1, int depth)
        {
            if (Win(game1) == 1)
                return 10 - depth;
            else if (Win(game1) == -1)
                return  depth - 10;
            else
                return 0;
        }

        int minimax(int[,] game1, int player, int depth)
        {
            int boba = Win(game1);
            if (boba != 0)
            {
                return score(game1, depth);
            }
            depth++;
            int[,] tempGame = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tempGame[i, j] = game1[i, j];
                }
            }
            List<int> scores = new List<int>(); 
            List<Point> moves = new List<Point>(); 
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tempGame[i, j] == 0)
                    {
                        tempGame[i, j] = player;
                        scores.Add(minimax(tempGame, -player, depth));
                        moves.Add(new Point(i, j));
                        
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 3; y++)
                            {
                                tempGame[x, y] = game1[x, y];
                            }
                        }
                    }
                }
            }
            if (player == 1)
            {
                int maxScore = scores[0];
                int index = 0;
                for (int i = 1; i < scores.Count; i++)
                {
                    if (maxScore < scores[i])
                    {
                        maxScore = scores[i];
                        index = i;
                    }
                }
                game1[moves[index].X, moves[index].Y] = player;
                return scores[index];
            }
            else
            {
                int minScore = scores[0];
                int index = 0;
                for (int i = 1; i < scores.Count; i++)
                {
                    if (minScore > scores[i])
                    {
                        minScore = scores[i];
                        index = i;
                    }
                }
                game1[moves[index].X, moves[index].Y] = player;
                return scores[index];
            }
        }
        public void DrawSign() 
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
            label8.ForeColor = Color.Black;
            label9.ForeColor = Color.Black;
            if (game[0, 0] == 1) label1.Text = "X";
            else if (game[0, 0] == -1) label1.Text = "O";
            if (game[0, 1] == 1)  label2.Text = "X";
            else if (game[0, 1] == -1) label2.Text = "O";
            if (game[0, 2] == 1)  label3.Text = "X";
            else if (game[0, 2] == -1) label3.Text = "O";
            if (game[1, 0] == 1)  label4.Text = "X";
            else if (game[1, 0] == -1) label4.Text = "O";
            if (game[1, 1] == 1)  label5.Text = "X";
            else if (game[1, 1] == -1) label5.Text = "O";
            if (game[1, 2] == 1)  label6.Text = "X";
            else if (game[1, 2] == -1) label6.Text = "O";
            if (game[2, 0] == 1)  label7.Text = "X";
            else if (game[2, 0] == -1) label7.Text = "O";
            if (game[2, 1] == 1)  label8.Text = "X";
            else if (game[2, 1] == -1) label8.Text = "O";
            if (game[2, 2] == 1)  label9.Text = "X";
            else if (game[2, 2] == -1) label9.Text = "O";            
        } 
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
            startGame();
            level = 2;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)   // If 2 players want to play
        {
            timer1.Enabled = false;
            startGame();
            level = 2;
        }      

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = new Point(e.X, e.Y);            
            int h, w;
            h = pictureBox1.Height / 3;
            w = pictureBox1.Width / 3;
            if (point.X > 0 && point.Y > 0 && point.X < w && point.Y < h)   // Cell 1
            {
                if (clickCounter % 2 == 1)
                {
                    label1.Text = "X";
                }
                else if (clickCounter % 2 == 0)
                {
                    label1.Text = "O";
                }
                clickCounter++;
            } else
            if (point.X > w && point.Y > 0 && point.X < 2*w && point.Y < h)   // Cell 2
            {
                if (clickCounter % 2 == 1)
                {
                    label2.Text = "X";                    
                }
                else if (clickCounter % 2 == 0)
                {
                    label2.Text = "O";                    
                }
                clickCounter++;
            } else
            if (point.X > 2*w && point.Y > 0 && point.X < 3*w && point.Y < h)   // Cell 3
            {
                if (clickCounter % 2 == 1)
                {
                    label3.Text = "X";                    
                }
                else if (clickCounter % 2 == 0)
                {
                    label3.Text = "O";                    
                }
                clickCounter++;
            } else
            if (point.X > 0 && point.Y > h && point.X < w && point.Y < 2*h)   // Cell 4
            {
                if (clickCounter % 2 == 1)
                {
                    label4.Text = "X";                    
                }
                else if (clickCounter % 2 == 0)
                {
                    label4.Text = "O";                    
                }
                clickCounter++;
            } else
            if (point.X > w && point.Y > h && point.X < 2*w && point.Y < 2*h)   // Cell 5
            {
                if (clickCounter % 2 == 1)
                {
                    label5.Text = "X";                    
                }
                else if (clickCounter % 2 == 0)
                {
                    label5.Text = "O";                    
                }
                clickCounter++;
            } else
            if (point.X > 2*w && point.Y > h && point.X < 3*w && point.Y < 2*h)   // Cell 6
            {
                if (clickCounter % 2 == 1)
                {
                    label6.Text = "X";                    
                }
                else if (clickCounter % 2 == 0)
                {
                    label6.Text = "O";                 
                }
                clickCounter++;
            } else
            if (point.X > 0 && point.Y > 2*h && point.X < w && point.Y < 3*h)   // Cell 7
            {
                if (clickCounter % 2 == 1)
                {
                    label7.Text = "X";                    
                }
                else if (clickCounter % 2 == 0)
                {
                    label7.Text = "O";                
                }
                clickCounter++;
            } else
            if (point.X > w && point.Y > 2*h && point.X < 2*w && point.Y < 3*h)   // Cell 8
            {
                if (clickCounter % 2 == 1)
                {
                    label8.Text = "X";                    
                }
                else if (clickCounter % 2 == 0)
                {
                    label8.Text = "O";                    
                }
                clickCounter++;
            } else
            if (point.X > 2*w && point.Y > 2*h && point.X < 3*w && point.Y < 3*h)   // Cell 9
            {
                if (clickCounter % 2 == 1)
                {
                    label9.Text = "X";
                }
                else if (clickCounter % 2 == 0)
                {
                    label9.Text = "O";                    
                }
                clickCounter++;
            }

            if (clickCounter % 2 == 0)   // on label10 - message for remind who mast go 
            {
                game[point.Y / w, point.X / h] = 1;  //1 is "X"
                label10.Text = "Player turn: O";
            }
            else
            {
                game[point.Y / w, point.X / h] = -1;  // -1 is "O"
                label10.Text = "Player turn: X";
            }
            Form2 form2 = new Form2();    // window with message about winner
            c = Win();
            if (c == 1)
            {
                form2.message = "X is winner!";
                timer1.Enabled = false;
                WriteStat(level, c);
                form2.ShowDialog();
                
            } else 
            if (c == -1)
            {
                form2.message = "O is winner!";
                timer1.Enabled = false;
                WriteStat(level, c);
                form2.ShowDialog();
                
            } else 
            if (c == 2)
            {
                form2.message = "Nobody is winner!";
                timer1.Enabled = false;
                WriteStat(level, c);
                form2.ShowDialog();
            }
            if (form2.again == 1)
            {
                playersToolStripMenuItem_Click(sender, e);   // if player want to play again                    
            }
            if (form2.again == 2)
            {
                newGameToolStripMenuItem_Click(sender, e);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(b);
            g.DrawLine(new Pen(Color.Black, 10), pictureBox1.Width/3, 10 , pictureBox1.Width/3, pictureBox1.Height -10);
            g.DrawLine(new Pen(Color.Black, 10), (pictureBox1.Width/3)*2, 10 , (pictureBox1.Width/3)*2, pictureBox1.Height -10 );
            g.DrawLine(new Pen(Color.Black, 10), 10, (pictureBox1.Height/3),  pictureBox1.Width -10, pictureBox1.Height/3);
            g.DrawLine(new Pen(Color.Black, 10), 10, (pictureBox1.Height/3)*2,  pictureBox1.Width - 10, (pictureBox1.Height/3)*2);
            pictureBox1.Image = b;
            label10.Text = "";
        }

        private void easyToolStripMenuItem_Click(object sender, EventArgs e)  //chosed easy level
        {
            easyToolStripMenuItem.Checked = true;
            hardToolStripMenuItem.Checked = false;
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)  // chosed hard level
        {
            easyToolStripMenuItem.Checked = false;
            hardToolStripMenuItem.Checked = true;
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)    // player want to be "X"
        {
            xToolStripMenuItem.Checked = true;
            oToolStripMenuItem.Checked = false;
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)    //  player want to be "O"
        {
            xToolStripMenuItem.Checked = false;
            oToolStripMenuItem.Checked = true;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)   //new game with PC
        {            
            startGame();
            timer1.Enabled = true;
            if (easyToolStripMenuItem.Checked == true) level = 0;
            else if (easyToolStripMenuItem.Checked == false) level = 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (easyToolStripMenuItem.Checked == true)
            {
                if (xToolStripMenuItem.Checked == true)   // Human is "X", PC is "O"
                {
                    if (clickCounter % 2 == 0 && clickCounter <= 9)
                    {
                        pcOStep();
                        Form2 form2 = new Form2();    // window with message about winner
                        c = Win();
                        if (c == 1)
                        {
                            form2.message = "X is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        else
                        if (c == -1)
                        {
                            form2.message = "O is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        else
                        if (c == 2)
                        {
                            form2.message = "Nobody is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        if (form2.again == 1)
                        {
                            playersToolStripMenuItem_Click(sender, e);   // if player want to play again                    
                        }
                        if (form2.again == 2)
                        {
                            newGameToolStripMenuItem_Click(sender, e);
                        }
                    }
                    
                }
                if (oToolStripMenuItem.Checked == true)   //Human is "O", PC is "X"
                {
                    if (clickCounter % 2 == 1 && clickCounter <= 9)
                    {
                        pcXStep();
                        Form2 form2 = new Form2();    // window with message about winner
                        c = Win();
                        if (c == 1)
                        {
                            form2.message = "X is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        else
                        if (c == -1)
                        {
                            form2.message = "O is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        else
                        if (c == 2)
                        {
                            form2.message = "Nobody is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        if (form2.again == 1)
                        {
                            playersToolStripMenuItem_Click(sender, e);   // if player want to play again                    
                        }
                        if (form2.again == 2)
                        {
                            newGameToolStripMenuItem_Click(sender, e);
                        }
                    }
                }

            } else if (hardToolStripMenuItem.Checked == true)
            {
                if (xToolStripMenuItem.Checked == true)
                {
                    player = -1;                
                    if (clickCounter %2 == 0 && clickCounter < 9)
                    {
                        minimax(game, player, 0);
                        DrawSign();
                        clickCounter++;
                        Form2 form2 = new Form2();    // window with message about winner
                        c = Win();
                        if (c == 1)
                        {
                            form2.message = "X is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        else
                        if (c == -1)
                        {
                            form2.message = "O is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        else
                        if (c == 2)
                        {
                            form2.message = "Nobody is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        if (form2.again == 1)
                        {
                            playersToolStripMenuItem_Click(sender, e);   // if player want to play again                    
                        }
                        if (form2.again == 2)
                        {
                            newGameToolStripMenuItem_Click(sender, e);
                        }
                    }

                }
                if (oToolStripMenuItem.Checked == true)
                {
                    player = 1;
                    if (clickCounter % 2 == 1 && clickCounter <= 9)
                    {
                        minimax(game, player, 0);
                        DrawSign();
                        clickCounter++;
                        Form2 form2 = new Form2();    // window with message about winner
                        c = Win();
                        if (c == 1)
                        {
                            form2.message = "X is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        else
                        if (c == -1)
                        {
                            form2.message = "O is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        else
                        if (c == 2)
                        {
                            form2.message = "Nobody is winner!";
                            timer1.Enabled = false;
                            WriteStat(level, c);
                            form2.ShowDialog();
                        }
                        if (form2.again == 1)
                        {
                            playersToolStripMenuItem_Click(sender, e);   // if player want to play again                    
                        }
                        if (form2.again == 2)
                        {
                            newGameToolStripMenuItem_Click(sender, e);
                        }
                    }
                }
            }
        }
        public int[] ReadStat()
        {
            string file = System.IO.Path.GetFullPath("statistics.txt");
            if (File.Exists(file))
            {
                FileStream fs = File.OpenRead(file);
                StreamReader sr = new StreamReader(fs);
                string line;
                string[] cutline;
                line = sr.ReadLine();
                cutline = line.Split();
                for (int i = 0; i<9; i++)
                {
                    stat[i] = Convert.ToInt32(cutline[i]);
                }
                sr.Close();
                fs.Close();
                return stat;
            }
            else
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(baseDir, "statistics.txt");
                FileStream fs = File.Create(filePath);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine("0 0 0 0 0 0 0 0 0");
                sw.Close();
                fs.Close();
                stat = new int[9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
                return stat;
            }
        }

        public void WriteStat(int level, int winner)   //level: 0 - easy, 1 - hard, 2 - two people; winner: 1 - "X", -1 - "O", 2 - nobody;
        {
            stat = ReadStat();
            if (level == 0)
            {
                if (winner == 1)
                {
                    stat[0]++;
                } else if (winner == -1)
                {
                    stat[1]++;
                } else if (winner == 2)
                {
                    stat[2]++;
                }
            } else if (level == 1)
            {
                if (winner == 1)
                {
                    stat[3]++;
                }
                else if (winner == -1)
                {
                    stat[4]++;
                }
                else if (winner == 2)
                {
                    stat[5]++;
                }
            } else if (level == 2)
            {
                if (winner == 1)
                {
                    stat[6]++;
                }
                else if (winner == -1)
                {
                    stat[7]++;
                }
                else if (winner == 2)
                {
                    stat[8]++;
                }
            }

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDir, "statistics.txt");
            FileStream fs = File.Create(filePath);
            StreamWriter sw = new StreamWriter(fs);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 9; i++) sb.Append(stat[i]+ " ");
            sw.WriteLine(sb.ToString());
            
            sw.Close();
            fs.Close();
        }

        private void resetStatisticsToolStripMenuItem_Click(object sender, EventArgs e)    //delete statistics
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(baseDir, "statistics.txt");
            FileStream fs = File.Create(filePath);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("0 0 0 0 0 0 0 0 0");
            sw.Close();
            fs.Close();
            stat = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)  //show form with statistics
        {
            stat = ReadStat();
            Stat form3 = new Stat();   //new form for statistics
            form3.statInfo = stat;
            form3.CountStat();
            form3.ShowDialog();
        }
    }
}