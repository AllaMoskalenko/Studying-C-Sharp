namespace HomeWork13
    /*
    сделать "бильярдный стол":
k - это длинна, которую задает пользователь.
из левого верхнего угла выходит прямая, длинной k, под углом 45 градусов потом, пропуск в том же направлении длинной k, и так далее:
пропуск-штрих-пропуск-штрих...
если прямая упирается в границу, то она отражается как в "бильярде".
если прямая упирается в угол, то закончить алгоритм.
задача: 
1. ввести целое k и вывести узор на екран.
2. дать возможность пользователю менять размер экрана.
учитывать, что ширина и высота кратны k.
    */
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k, h, w, fh, fw, marker;
            k = Convert.ToInt32(textBox1.Text);
            Point point1 = new Point(0 , 0);
            Point point2 = new Point(k , k);
            Pen pen1 = new Pen( Color.Blue, 2);
            Graphics g = pictureBox1.CreateGraphics();

            h = pictureBox1.Height;
            w = pictureBox1.Width;

            fh = 1;
            fw = 1;
            marker = 1;

            //risuyu
            while (true)
            {
                if (marker == 1)
                {
                    g.DrawLine(pen1, point1, point2);
                    marker = 0;
                }
                else marker = 1;

                point1.X = point2.X;
                point1.Y = point2.Y;
                point2.X += k * fw;
                point2.Y += k * fh;
                if (point2.X > w && point2.Y >h)
                {
                    break;
                }
                if (point2.X < 0 && point2.Y > h)
                {
                    break;
                }

                if (point2.X > w && point2.Y < 0)
                {
                    break;
                }
                if (point2.X < 0 && point2.Y < 0)
                {
                    break;
                }
                if (point2.Y > h)    //proverka dostizheniya nizhney granitcy
                {
                    fh = -1;
                    point2.Y += 2 * k * fh;
                }
                if (point2.X > w)       //proverka dostizheniya pravoy granitcy
                {
                    fw = -1;
                    point2.X += 2 * k * fw;
                }
                if (point2.Y < 0)
                {
                    fh = 1;
                    point2.Y += 2 * k * fh;
                }
                if (point2.X < 0)
                {
                    fw = 1;
                    point2.X += 2 * k * fw;
                }
            }

        }
    }
}
