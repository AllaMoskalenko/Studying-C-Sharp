using System.Drawing;


namespace Sorting_Library
{
    public static class Sort
    {
        public static int height, width;    // size of picturebox
        public static int max;              //max value of array
        public static void DrawArr ( ref Graphics g, int[] mas)
        {
            int x = 10, w = ((width-10)/mas.Length)-1;

            for (int i = 0; i < mas.Length; i++)
            {
                g.DrawRectangle(new Pen(Color.Black, 2), x, height - (mas[i] * height) / max, w, (mas[i]*height)/max);
                g.FillRectangle(new SolidBrush(Color.Beige), x, height - (mas[i] * height) / max, w, (mas[i] * height) / max);
                x += (w+1);
            }
        }
        public static void DrawArr(ref Graphics g, int[] mas, int a, int b)
        {
            int x = 10, w = ((width - 10) / mas.Length) - 1;

            for (int i = 0; i < mas.Length; i++)
            {
                if (i == a)
                {
                    g.DrawRectangle(new Pen(Color.Black, 2), x, height - (mas[i] * height) / max, w, (mas[i] * height) / max);
                    g.FillRectangle(new SolidBrush(Color.Blue), x, height - (mas[i] * height) / max, w, (mas[i] * height) / max);
                    x += (w + 1);
                }
                if (i == b)
                {
                    g.DrawRectangle(new Pen(Color.Black, 2), x, height - (mas[i] * height) / max, w, (mas[i] * height) / max);
                    g.FillRectangle(new SolidBrush(Color.Blue), x, height - (mas[i] * height) / max, w, (mas[i] * height) / max);
                    x += (w + 1);
                }
                else
                {
                    g.DrawRectangle(new Pen(Color.Black, 2), x, height - (mas[i] * height) / max, w, (mas[i] * height) / max);
                    g.FillRectangle(new SolidBrush(Color.Beige), x, height - (mas[i] * height) / max, w, (mas[i] * height) / max);
                    x += (w + 1);
                }
            }
        }

        public static int[] BubbleSort (Graphics g, int[] mas)
        {
            int max;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas.Length-i-1; j++)
                {
                    if (mas[j] > mas[j + 1])
                    {
                        max = mas[j];
                        mas[j] = mas[j + 1];
                        mas[j + 1] = max;
                        DrawArr(ref g, mas, j, j + 1);
                    }
                }
            }
            return mas;
        }


        







    }
}