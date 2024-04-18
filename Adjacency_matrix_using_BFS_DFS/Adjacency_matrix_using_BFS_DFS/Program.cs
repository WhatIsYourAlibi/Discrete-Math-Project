namespace Adjacency_matrix_using_BFS_DFS;

using System;
using System.Diagnostics;
using System.Collections.Generic;

public class GraphExperiment
{
    private const int Trials = 20;

    public static void Main(string[] args)
    {
        int[] sizes = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
        double[] densities = { 0.1, 0.25, 0.4, 0.55, 0.7 };

        foreach (int size in sizes)
        {
            foreach (double density in densities)
            {
                Console.WriteLine($"Size: {size}, Density: {density:F2}");
                
                double averageTimeBFSMatrix = MeasureAverageTime(size, density, true, "BFS");
                Console.WriteLine($"BFS with Matrix: {averageTimeBFSMatrix:F4} ms");

                double averageTimeBFSList = MeasureAverageTime(size, density, false, "BFS");
                Console.WriteLine($"BFS with List: {averageTimeBFSList:F4} ms");

                double averageTimeDFSMatrix = MeasureAverageTime(size, density, true, "DFS");
                Console.WriteLine($"DFS with Matrix: {averageTimeDFSMatrix:F4} ms");

                double averageTimeDFSList = MeasureAverageTime(size, density, false, "DFS");
                Console.WriteLine($"DFS with List: {averageTimeDFSList:F4} ms");
            }
        }
    }

    private static double MeasureAverageTime(int size, double density, bool useMatrix, string method)
    {
        double totalTime = 0;

        for (int i = 0; i < Trials; i++)
        {
            Graph graph = GraphGenerator.GenerateRandomGraph(size, density);
            
            Stopwatch stopwatch = Stopwatch.StartNew();

            if (method == "BFS")
            {
                BFS bfs = new BFS(graph);
                if (useMatrix)
                {
                    int[][] reachabilityMatrix = bfs.BuildReachabilityMatrixUsingBFS();
                }
                else
                {
                    int[][] reachabilityMatrix = bfs.BuildReachabilityMatrixFromListUsingBFS(graph.GetAdjacencyList());
                }
            }
            else
            {
                DFS dfs = new DFS(graph);
                if (useMatrix)
                {
                    int[][] reachabilityMatrix = dfs.BuildReachabilityMatrixUsingDFS();
                }
                else
                {
                    int [][] reachabilityMatrix = dfs.BuildReachabilityMatrixFromListUsingDFS(graph.GetAdjacencyList());
                }
            }

            stopwatch.Stop();
            totalTime += stopwatch.ElapsedMilliseconds;
        }

        return totalTime / Trials;
    }
    
    private static void DisplayMatrix(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                Console.Write(matrix[i][j] + " ");
            }
            Console.WriteLine();
        }
    }

    private static void DisplayList(List<int>[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            Console.Write(i + ": ");
            foreach (var item in list[i])
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}