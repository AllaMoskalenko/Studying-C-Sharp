using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork19
{
    static class MyExtensions
    {
        public static string All_Matrixes(this Graph graph)
        {
            string matrixes = "Matrix Adjacency: \n";
            int[,] m_a = graph.Matrix_Adjacency();
            for (int i = 0; i<m_a.GetLength(0); i++)
            {
                for (int j = 0; j < m_a.GetLength(1); j++)
                {
                    matrixes += m_a[i, j] + " ";
                }
                matrixes += "\n";
            }
            matrixes += "Matrix Incidencey: \n";
            int[,] m_i = graph.Matrix_Incidencey();
            for (int i = 0; i < m_i.GetLength(0); i++)
            {
                for (int j = 0; j < m_i.GetLength(1); j++)
                {
                    matrixes += m_i[i, j] + " ";
                }
                matrixes += "\n";
            }
            matrixes += "List Adjacency: \n";
            List<string>[] l_a = new List<string>[graph.List_Adjacency().Length];
                l_a = graph.List_Adjacency();
            for (int i=0; i<l_a.Length; i++)
            {
                for (int j = 0; j < l_a[i].Count; j++)
                {
                    matrixes += l_a[i][j] + " ";
                }
                matrixes += "\n";
            }
            return matrixes;
        }
    }
}
