using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork12
{
    internal class Matrix_3x3
    {
        public int[,] arr;

        public Matrix_3x3(int[,] arr1)
        {
            arr = new int[3,3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++) 
                {
                    this.arr[i,j] = arr1[i,j];
                }
        }

        public Matrix_3x3 ()
        {
            this.arr = new int[3,3];
        }


        public int Determinant()
        {
            int d;
            d = arr[0, 0] * arr[1, 1] * arr[2, 2] +
                 arr[0, 1] * arr[1, 2] * arr[2, 0] +
                 arr[1, 0] * arr[2, 1] * arr[0, 2] -
                 arr[0, 2] * arr[1, 1] * arr[2, 0] -
                 arr[0, 0] * arr[1, 2] * arr[2, 1] -
                 arr[0, 1] * arr[1, 0] * arr[2, 2];
            return d;
        }

        public static Matrix_3x3 Add (Matrix_3x3 m1, Matrix_3x3 m2)
        {
            Matrix_3x3 m3 = new Matrix_3x3();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m3.arr[i, j] = m1.arr[i, j] + m2.arr[i, j];
                }

            }
            
            return m3;
        }

        public string ShowMatrix ()
        {
            return   arr[0, 0] + " " + arr[0, 1] + " " + arr[0, 2] + "\n" +
                     arr[1, 0] + " " + arr[1, 1] + " " + arr[1, 2] + "\n" +
                     arr[2, 0] + " " + arr[2, 1] + " " + arr[2, 2];
        }
        public override string ToString()
        {
            return arr[0, 0] + " " + arr[0, 1] + " " + arr[0, 2] + "\n" +
                     arr[1, 0] + " " + arr[1, 1] + " " + arr[1, 2] + "\n" +
                     arr[2, 0] + " " + arr[2, 1] + " " + arr[2, 2];
        }
    }
}
