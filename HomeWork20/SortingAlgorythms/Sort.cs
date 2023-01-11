using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace SortingAlgorythms
{
    public static class Sort
    {
        public static int height, width;    // size of picturebox
        public static int max;              //max value of array
        public static Bitmap bmp;
        public static Graphics g;
        static Color backColor = Color.FromArgb(128, 128, 128);
        public static void Init(int w, int h)
        {
            bmp = new Bitmap(w, h);
            height = h;
            width = w;
            g = Graphics.FromImage(bmp);
        }
        public static void DrawArr(int[] arr)
        {
            int x = 10, w = ((width - 10) / arr.Length) - 1;
            g.Clear(backColor);
            for (int i = 0; i < arr.Length; i++)
            {
                g.FillRectangle(new SolidBrush(Color.LightGoldenrodYellow), x, height - (arr[i] * height) / max, w, (arr[i] * height) / max);
                g.DrawRectangle(new Pen(Color.Gold, 1), x, height - (arr[i] * height) / max, w, (arr[i] * height) / max);
                x += (w + 1);
            }
        }
        public static void DrawArr(int[] arr, int a, int b, ref PictureBox pb)
        {
            int x = 10, w = ((Sort.width - 10) / arr.Length) - 1;
            g.Clear(backColor);
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == a)
                {
                    g.FillRectangle(new SolidBrush(Color.CornflowerBlue), x, Sort.height - (arr[i] * Sort.height) / max, w, (arr[i] * Sort.height) / max);
                    g.DrawRectangle(new Pen(Color.DarkBlue, 1), x, Sort.height - (arr[i] * Sort.height) / max, w, (arr[i] * Sort.height) / max);
                    x += (w + 1);
                }
                else if (i == b)
                {
                    g.FillRectangle(new SolidBrush(Color.CornflowerBlue), x, Sort.height - (arr[i] * Sort.height) / max, w, (arr[i] * Sort.height) / max);
                    g.DrawRectangle(new Pen(Color.DarkBlue, 1), x, Sort.height - (arr[i] * Sort.height) / max, w, (arr[i] * Sort.height) / max);
                    x += (w + 1);
                }
                else
                {
                    g.FillRectangle(new SolidBrush(Color.LightGoldenrodYellow), x, Sort.height - (arr[i] * Sort.height) / max, w, (arr[i] * Sort.height) / max);
                    g.DrawRectangle(new Pen(Color.Gold, 1), x, Sort.height - (arr[i] * Sort.height) / max, w, (arr[i] * Sort.height) / max);
                    x += (w + 1);
                }
            }
            pb.Image = bmp;
            pb.Refresh();
        }
        public static void FinDrawArr(int[] arr, ref PictureBox pb, Color color)
        {
            int x = 10, w = ((Sort.width - 10) / arr.Length) - 1;

            for (int i = 0; i < arr.Length; i++)
            {
                g.FillRectangle(new SolidBrush(color), x, Sort.height - (arr[i] * Sort.height) / max, w, (arr[i] * Sort.height) / max);
                g.DrawRectangle(new Pen(Color.Black, 1), x, Sort.height - (arr[i] * Sort.height) / max, w, (arr[i] * Sort.height) / max);
                pb.Image = bmp;
                pb.Refresh();
                Thread.Sleep(25);
                x += (w + 1);
            }
        }
        public static int[] BubbleSort(int[] arr, ref PictureBox pb)
        {
            int max;
            PictureBox pb2 = pb;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        max = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = max;
                        DrawArr(arr, j + 1, j, ref pb2);
                        Thread.Sleep(50);
                    }
                }
            }
            FinDrawArr(arr, ref pb, Color.Orchid);
            return arr;
        }

        public static int[] GnomeSort(int[] arr, ref PictureBox pb)
        {
            int i = 1, j = 2, temp;

            while (i < arr.Length)
            {
                if (arr[i - 1] < arr[i])
                {
                    i = j;
                    j = i + 1;
                } else
                {
                    temp = arr[i];
                    arr[i] = arr[i - 1];
                    arr[i - 1] = temp;
                    DrawArr(arr, i, i - 1, ref pb);
                    Thread.Sleep(50);
                    i = i - 1;
                    if (i == 0)
                    {
                        i = j;
                        j = j + 1;
                    }
                }
            }
            FinDrawArr(arr, ref pb, Color.PaleGreen);
            return arr;
        }

        public static int[] SelectionSort(int[] arr, ref PictureBox pb)
        {
            int min, temp;
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                min = i;
                for (int j = i + 1; j < arr.Length; ++j)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                temp = arr[i];
                arr[i] = arr[min];
                arr[min] = temp;
                DrawArr(arr, i, min, ref pb);
                Thread.Sleep(50);
            }
            FinDrawArr(arr, ref pb, Color.LawnGreen);
            return arr;
        }

        public static int[] InsertionSort(int[] arr, ref PictureBox pb)
        {
            int j, temp;
            for (int i = 1; i < arr.Length; i++)
            {
                temp = arr[i];
                j = i;
                while (j > 0 && arr[j - 1] > temp)
                {
                    arr[j] = arr[j - 1];
                    j--;
                    DrawArr(arr, j - 1, j, ref pb);
                    Thread.Sleep(50);
                }
                arr[j] = temp;
                DrawArr(arr);
            }
            FinDrawArr(arr, ref pb, Color.IndianRed);
            return arr;
        }

        public static int[] QuickSort(int[] arr, ref PictureBox pb)
        {
            arr = Qsort(arr, 0, arr.Length - 1, ref pb);

            int[] Qsort(int[] array, int left, int right, ref PictureBox pbox)
            {
                int i = left;
                int j = right;
                int standard = array[right];
                while (i <= j)
                {
                    while (array[i] < standard)
                    {
                        i++;
                    }
                    while (array[j] > standard)
                    {
                        j--;
                    }
                    if (i <= j)
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                        i++;
                        j--;
                        DrawArr(array, i, j, ref pbox);
                        Thread.Sleep(70);
                    }
                }
                if (left < j)
                {
                    Qsort(array, left, j, ref pbox);
                }
                if (i < right)
                {
                    Qsort(array, i, right, ref pbox);
                }

                return array;
            }

            FinDrawArr(arr, ref pb, Color.Maroon);
            return arr;
        }

        public static int[] ShellSort(int[] arr, ref PictureBox pb)
        {
            int temp;
            int d = arr.Length / 2;
            while (d>=1)
            {
                for (int i = d; i < arr.Length; i++)
                {
                    int j = i;
                    while (j >= d && arr[j - d] > arr[j])
                    {
                        temp = arr[j];
                        arr[j] = arr[j - d];
                        arr[j - d] = temp;
                        j = j - d;
                        DrawArr(arr, j, j - d, ref pb);
                        Thread.Sleep(50);
                    }
                }
                d = d / 2;
            }
            FinDrawArr(arr, ref pb, Color.Blue);
            return arr;
        }

        public static int[] RadixSort(int[] arr, ref PictureBox pb)
        {

            return arr;
        }

        static void Merge(int[] arr, int lowIndex, int middleIndex, int highIndex, ref PictureBox pb)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (arr[left] < arr[right])
                {
                    tempArray[index] = arr[left];
                    left++;                    
                }
                else
                {
                    tempArray[index] = arr[right];
                    right++;
                }
                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = arr[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = arr[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                arr[lowIndex + i] = tempArray[i];
            }
        }
                
        static int[] MergeSort(int[] array, int lowIndex, int highIndex, ref PictureBox pb)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                
                MergeSort(array, lowIndex, middleIndex, ref pb);
                DrawArr(array, middleIndex, lowIndex, ref pb);
                Thread.Sleep(50);
                
                MergeSort(array, middleIndex + 1, highIndex, ref pb);
                DrawArr(array, middleIndex+1, highIndex, ref pb);
                Thread.Sleep(50);
                
                Merge(array, lowIndex, middleIndex, highIndex, ref pb);
                DrawArr(array, highIndex, lowIndex, ref pb);
                Thread.Sleep(50);
            }
            return array;
        }

        public static int[] MergeSort(int[] arr, ref PictureBox pb)
        {
            arr = MergeSort(arr, 0, arr.Length - 1, ref pb);
            FinDrawArr(arr, ref pb, Color.Orange);
            return arr;
        }
    }
}
