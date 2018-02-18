using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs_alg
{
    internal class Vertex
    {
        internal Vertex(int num)
        {
            this.number = num;
            neighbors = new List<Vertex>();
        }
        internal int number;
        internal List<Vertex> neighbors;
    }



    internal class Graph
    {
        internal Graph(int count)
        {
            this.count = count;
            vertex = new Vertex[count];
        }
        internal int count;
        internal Vertex[] vertex;

        internal void read()
        {
            int count_edges;
            Console.WriteLine("Write numbers of edges: ");
            bool k = Int32.TryParse(Console.ReadLine(), out count_edges);
            for (int iter = 0; iter < count; iter++)
            {
                vertex[iter] = new Vertex(iter);
            }
            for (int iter = 0; iter < count_edges; iter++)
            {
                string putin = Console.ReadLine();
                string[] edge = putin.Split(' ');
                int i;
                int j;
                bool b = Int32.TryParse(edge[0], out i);
                bool c = Int32.TryParse(edge[1], out j);
                vertex[i].neighbors.Add(vertex[j]);
            }
        }

        internal int[,] matrix()
        {
            int[,] matrix = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                if (vertex[i].neighbors.Count != 0)
                {
                    for (int j = 0; j < vertex[i].neighbors.Count; j++)
                        matrix[(vertex[i].number), (vertex[i].neighbors[j].number)] = 1;
                }
            }
            return matrix;
        }

        internal List<Vertex> bfs(int index)
        {
            Queue<Vertex> queue = new Queue<Vertex>();
            List<Vertex> result = new List<Vertex>();
            bool[] check = new bool[count];
            for (int i = 0; i < count; i++)
                check[i] = true;
            queue.Enqueue(vertex[index]);
            while (queue.Count != 0)
            {
                Vertex temp = queue.Dequeue();
                result.Add(temp);
                for (int j = 0; j < temp.neighbors.Count; j++)
                {
                    if (check[temp.neighbors[j].number] == true)
                    {
                        check[temp.neighbors[j].number] = false;
                        queue.Enqueue(temp.neighbors[j]);
                    }
                }
            }
            return result;
        }

        internal List<Vertex> dfs(int index)
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(5);
            g.read();
            int[,] m = new int[5, 5];
            m = g.matrix();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }

            List<Vertex> temp = new List<Vertex>();
            temp = g.bfs(2);
            for(int i = 0; i < temp.Count; i++)
            {
                Console.WriteLine(temp[i].number + " ");
            }

            Console.ReadKey();
        }
    }
}
