using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork19
{
    public class Graph
    {
        public List <Vertex> vertexes;
        public List <Edge> edges;
        
        public int radius = 20;
        
        public Graph ()
        {
            vertexes = new List <Vertex> ();
            edges = new List <Edge> ();
            
        }
        public Graph(List<string> file_lines)     //for creating graph from saved in file
        {
            vertexes = new List<Vertex>();
            edges = new List<Edge>();
            int vert_count;
            string[] temp;
            vert_count = Convert.ToInt32(file_lines[0]);
            for (int i = 0; i < vert_count; i++)
            {
                temp = file_lines[i + 1 + vert_count].Split();
                Point point = new Point ();
                point.X = Convert.ToInt32(temp[0]);
                point.Y = Convert.ToInt32(temp[1]);
                vertexes.Add(new Vertex(point, file_lines[i + 1]));
            }
            for (int i = 1 + vert_count * 2, k = 0; k < vert_count; i++, k++)
            {
                temp = file_lines[i].Split();
                for (int j = k; j < temp.Length; j++)
                {
                    if (int.Parse(temp[j]) != 0)
                        edges.Add(new Edge(k, j, int.Parse(temp[j])));
                }
            }
        }

        public void CreateVertex(Point point)
        {
            vertexes.Add(new Vertex(point,vertexes.Count));
            
        }
        public void DeleteVertex(int index) 
        {
            for (int i=0; i < edges.Count; i++)
            {
                if (edges[i].vert1 == index || edges[i].vert2 == index)
                {
                    edges.RemoveAt(i);
                    i--;
                }
            }
            vertexes.RemoveAt(index);
            for (int j = 0; j < edges.Count; j++)
            {
                if (edges[j].vert1 > index)
                {
                    edges[j].vert1--;
                }
                if (edges[j].vert2 > index)
                {
                    edges[j].vert2--;
                }
            }

        }
        public void CreateEdge(int vertex1, int vertex2, int weight=1) 
        {
            bool needCreate = true;
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].vert1 == vertex1 && edges[i].vert2 == vertex2 || edges[i].vert1 == vertex2 && edges[i].vert2 == vertex1)
                {
                    edges[i].weight = weight; 
                    needCreate = false;
                }                
            }
            if (needCreate) edges.Add(new Edge(vertex1, vertex2, weight));
        }
        public void DeleteEdge(int vertex1, int vertex2)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].vert1 == vertex1 && edges[i].vert2 == vertex2 || edges[i].vert1 == vertex2 && edges[i].vert2 == vertex1)
                {
                    edges.RemoveAt(i);
                }
            }
        }
        
        public void DrawGraph(Graphics g) 
        {
            Point point1, point2, point3;
                        
            for (int j = 0; j < edges.Count; j++)
            {
                int v1 = edges[j].vert1;
                point1 = new Point(vertexes[v1].point.X, vertexes[v1].point.Y);
                int v2 = edges[j].vert2;
                point2 = new Point(vertexes[v2].point.X, vertexes[v2].point.Y);
                g.DrawLine(new Pen(Color.Black, 2), point1, point2);
                point3 = new Point((vertexes[v1].point.X + vertexes[v2].point.X) / 2, (vertexes[v1].point.Y + vertexes[v2].point.Y) / 2);
                g.FillEllipse(new SolidBrush(Color.White), point3.X - radius/2, point3.Y-radius/2, radius, radius);
                g.DrawString(edges[j].weight.ToString(), new Font(FontFamily.GenericSansSerif, 12), new SolidBrush(Color.Blue), new Point(point3.X-radius/2, point3.Y-radius/2));
            }
            for (int i = 0; i < vertexes.Count; i++)
            {
                g.FillEllipse(new SolidBrush(vertexes[i].colorok), vertexes[i].point.X - radius / 2, vertexes[i].point.Y - radius / 2, radius, radius);
                g.DrawEllipse(new Pen(Color.Black, 2), vertexes[i].point.X-radius/2, vertexes[i].point.Y-radius/2, radius, radius);
                if (vertexes[i].name == "")
                {
                    g.DrawString(i.ToString(), new Font(FontFamily.GenericSansSerif, 12), new SolidBrush(Color.Black),
                        new Point(vertexes[i].point.X - radius / 2, vertexes[i].point.Y - radius / 2));
                } else
                {
                    g.DrawString(vertexes[i].name, new Font(FontFamily.GenericSansSerif, 12), new SolidBrush(Color.Black),
                        new Point(vertexes[i].point.X - radius / 2, vertexes[i].point.Y - radius / 2));
                }
            }
        }
        public int index_of_vertex (Point p)
        {
            int answer = -1;
            for (int i = 0; i < vertexes.Count; i++)
            {
                if (Math.Abs(vertexes[i].point.X - p.X) < radius && Math.Abs(vertexes[i].point.Y - p.Y) < radius)
                {
                    answer = i;
                }
            }
            return answer;
        }

        public string[] Save_Graph()
        {
            int count = vertexes.Count;
            string[] adjacency = new string[count*3+1];

            adjacency[0] = vertexes.Count.ToString();   // amount of vertexes
            
            for (int i = 0; i < count; i++)
            {
                if (vertexes[0].name == "")
                {
                    adjacency[i+1]= i.ToString();    
                }
                else
                {
                    adjacency[i+1]= vertexes[i].name;   // names of vertexes
                }
            }
            for (int i = 0; i < count; i++)
            {
                adjacency[i+count+1] = vertexes[i].point.X.ToString() + " " + vertexes[i].point.Y.ToString();  //points for vertexes
            }
            int[,] temp_adj = new int[count, count];   //create matrix
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++) temp_adj[i, j] = 0; 
                
            for (int v = 0; v < count; v++)
            {
                for (int e = 0; e < edges.Count; e++)
                {
                    if (edges[e].vert1 == v)
                    {
                        temp_adj[v, edges[e].vert2] = edges[e].weight;
                    } else if (edges[e].vert2 == v)
                    {
                        temp_adj[v, edges[e].vert1] = edges[e].weight;
                    }
                }
            }
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count-1; j++)
                {
                    adjacency[i + count * 2 + 1] += temp_adj[i, j].ToString() + " ";     // matrix 
                }
                adjacency[i + count * 2 + 1]+= temp_adj[i, count-1].ToString();
            }

            return adjacency;
        }

        public int[,] Matrix_Adjacency()
        {
            int count = vertexes.Count;
            int[,] adj = new int[count, count];
            
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++) adj[i, j] = 0;

            for (int v = 0; v < count; v++)
            {
                for (int e = 0; e < edges.Count; e++)
                {
                    if (edges[e].vert1 == v)
                    {
                        adj[v, edges[e].vert2] = edges[e].weight;
                    }
                    else if (edges[e].vert2 == v)
                    {
                        adj[v, edges[e].vert1] = edges[e].weight;
                    }
                }
            }
            return adj;
        }
        public int[,] Matrix_Incidencey()
        {
            int count_v = vertexes.Count;
            int count_e = edges.Count;
            int[,] inc = new int[count_v, count_e];

            for (int i = 0; i < count_v; i++)
                for (int j = 0; j < count_e; j++) inc[i, j] = 0;

            for (int i = 0; i < count_v; i++)
                for (int j = 0; j < count_e; j++)
                {
                    if (edges[j].vert1 == i || edges[j].vert2 == i)
                    {
                        inc[i, j] = edges[j].weight;
                    }
                }

            return inc;
        }
        public List<string>[] List_Adjacency()
        {
            int count_v = vertexes.Count;
            int count_e = edges.Count;
            List<string>[] l_adj = new List<string>[count_v];
            for (int i =0; i < count_v; i++)
            {
                l_adj[i] = new List<string>();
            }
            
            for (int i = 0; i < count_v; i++)
                for (int j = 0; j < count_e; j++)
                {
                    if (edges[j].vert1 == i)
                        l_adj[i].Add(edges[j].vert2.ToString() + "(" + edges[j].weight.ToString() + ")");
                    else if (edges[j].vert2 == i)
                        l_adj[i].Add(edges[j].vert1.ToString() + "(" + edges[j].weight.ToString() + ")");
                }
            return l_adj;
        }

        public void Colorize()
        {
            Color[] colors = new Color[6] { Color.LightBlue, Color.Yellow, Color.MediumPurple, Color.Red, Color.Green, Color.Orange };
            int num = vertexes.Count;
            int ind = 0;
            int[,] adj = new int[num, num];
            adj = Matrix_Adjacency();
            List<Point> vert = new List<Point>();
            for (int i = 0; i < num; i++)
            {

                for (int j = 0; j < num; j++)
                {
                    if (adj[i, j] > 0) ind++;
                }

                vert.Add(new Point(i, ind));
                ind = 0;
            }


            Point temp = new Point();
            for (int i = 0; i < num - 1; i++)     //sort
            {
                for (int j = i + 1; j < num; j++)
                {
                    if (vert[i].Y < vert[j].Y)
                    {
                        temp.X = vert[i].X;
                        temp.Y = vert[i].Y;
                        vert[i] = new Point(vert[j].X, vert[j].Y);
                        vert[j] = new Point(temp.X, temp.Y);
                    }
                }
            }

            int k = 0, icol = 0, flag = 0;
            List<Point> used = new List<Point>();
            while (vert.Count > 0)
            {
                used.Clear();
                vertexes[vert[k].X].colorok = colors[icol];
                for (int j = k + 1; j < vert.Count; j++)
                {
                    if (adj[vert[j].X, vert[k].X] == 0)
                    {
                        flag = 0;
                        for (int a = 0; a < used.Count; a++)
                        {
                            if (adj[used[a].X, vert[j].X] > 0)
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {
                            vertexes[vert[j].X].colorok = colors[icol];
                            used.Add(vert[j]);
                            vert.Remove(vert[j]);
                            j--;
                        }
                    }
                }
                vert.Remove(vert[k]);
                icol++;
            }
        }

    }


    public class Vertex
    {
        public Point point;
        public string name;
        public Color colorok;

        public Vertex (Point point, int id)
        {
            this.point = point;
            this.name = id.ToString();
            this.colorok = Color.White;
        }
        public Vertex(Point point, string name)
        {
            this.point = point;
            this.name = name;
            this.colorok = Color.White;
        }


    }
    
    public class Edge
    {
        public int vert1, vert2, weight;

        public Edge (int vert1, int vert2, int weight)
        {
            this.vert1 = vert1;
            this.vert2 = vert2;
            this.weight = weight;
        }
    }
}
