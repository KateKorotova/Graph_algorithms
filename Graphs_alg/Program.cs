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
    }


    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph(5);
            g.read();
            int[,] m = new int[5,5];
            m = g.matrix();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write(m[i, j] + " ");
                Console.WriteLine();
            }

        Console.ReadKey();
        }
    }
}
