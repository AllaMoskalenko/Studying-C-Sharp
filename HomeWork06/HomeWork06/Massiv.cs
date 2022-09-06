using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork06
{
    internal class Massiv
    {
        public int m, n;
        public int [,] arr;
        public Massiv(int m, int n, int a, int b)
        {
            this.m = m;
            this.n = n;
            int i, j;
            Random r = new Random();
            arr=new int[m,n];
            for (i=0; i<m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    arr[i,j] = r.Next(a,b);
                }
            }

        }
        
        

    }
}
