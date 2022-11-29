using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork19
{
    public partial class Matrix_Show : Form
    {
        public Graph t_graph;
        public int[,] matrix;
        public List<string>[] list_adj;
        public int flag = 0; // 1 - matrix Adjacency, 2 - Matrix Incidencey, 3 = List Adjacency
        public Matrix_Show()
        {
            InitializeComponent();
        }
        private void Matrix_Show_Load(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersWidth = 50;
            dataGridView1.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            if (flag != 3)
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (flag == 1)      // 1 - headers of columns for matrix Adjacency
                    {
                        if (t_graph.vertexes[i].name == "")
                        { dataGridView1.Columns.Add((i).ToString(), i.ToString()); }
                        else
                        { dataGridView1.Columns.Add((i + 1).ToString(), t_graph.vertexes[i].name.ToString()); }
                        dataGridView1.Columns[i].Width = 50;
                    }
                    else
                    if (flag == 2)    // 2 - headers of columns for matrix Incidencey
                    {
                        if (t_graph.vertexes[t_graph.edges[i].vert1].name == "" && t_graph.vertexes[t_graph.edges[i].vert2].name == "")
                        {
                            dataGridView1.Columns.Add(i.ToString(), t_graph.edges[i].vert1.ToString() + "_" + t_graph.edges[i].vert2.ToString());
                        }
                        else
                        {
                            dataGridView1.Columns.Add(i.ToString(), t_graph.vertexes[t_graph.edges[i].vert1].name + "_" + t_graph.vertexes[t_graph.edges[i].vert2].name);
                        }
                        dataGridView1.Columns[i].Width = 50;
                    }
                }

                dataGridView1.Rows.Add(matrix.GetLength(0));

                for (int i = 0; i < matrix.GetLength(0); i++)  // headers of rows for any matrix
                {
                    if (t_graph.vertexes[i].name == "")
                        dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
                    else
                        dataGridView1.Rows[i].HeaderCell.Value = t_graph.vertexes[i].name;
                }

                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                    }

            } else // 3 - List Adjancency
            {
                int max = 0;
                for (int i = 0; i < list_adj.Length; i++)
                {
                    if (list_adj[i].Count > max) max = list_adj[i].Count;
                }

                for (int i = 0; i < max; i++)   
                {
                    dataGridView1.Columns.Add(i.ToString(), "");
                }
                dataGridView1.Rows.Add(t_graph.vertexes.Count);

                for (int i = 0; i < t_graph.vertexes.Count; i++)  // headers of rows for any matrix
                {
                    if (t_graph.vertexes[i].name == "")
                        dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
                    else
                        dataGridView1.Rows[i].HeaderCell.Value = t_graph.vertexes[i].name;
                }
                for (int i = 0; i < t_graph.vertexes.Count; i++)
                    for (int j = 0; j < list_adj[i].Count; j++)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = list_adj[i][j];
                    }
            }
        }    
    }
}
