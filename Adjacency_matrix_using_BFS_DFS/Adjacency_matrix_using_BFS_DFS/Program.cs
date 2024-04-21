namespace Adjacency_matrix_using_BFS_DFS;

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

public class GraphExperiment
{
    private const int Trials = 100;
    private static string resultFilePath = @"C:\Users\38097\Documents\GitHub\Discrete-Math-Project\Adjacency_matrix_using_BFS_DFS\Adjacency_matrix_using_BFS_DFS\experiment_results100.tsv";

    public static void Main(string[] args)
    {
        Console.WriteLine("Experiment started. Please wait...");

        int[] sizes = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
        double[] densities = { 0.1, 0.25, 0.4, 0.55, 0.7 };

        // Prepare the file to store the results
        using (StreamWriter writer = new StreamWriter(resultFilePath))
        {
            writer.WriteLine("Size\tDensity\tRepresentation\tMethod\tAverageTime(ms)");
            foreach (int size in sizes)
            {
                foreach (double density in densities)
                {
                    // Perform BFS and DFS with both representations and write to file
                    PerformExperiment(size, density, true, "BFS", writer);
                    PerformExperiment(size, density, false, "BFS", writer);
                    PerformExperiment(size, density, true, "DFS", writer);
                    PerformExperiment(size, density, false, "DFS", writer);
                }
            }
        }
        
        Console.WriteLine($"Experiment finished. Results written to {resultFilePath}");
    }

    private static void PerformExperiment(int size, double density, bool useMatrix, string method, StreamWriter writer)
    {
        double averageTime = MeasureAverageTime(size, density, useMatrix, method);
        writer.WriteLine($"{size}\t{density:F2}\t{(useMatrix ? "Matrix" : "List")}\t{method}\t{averageTime:F4}");
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
                int[][] reachabilityMatrix = useMatrix ?
                    bfs.BuildReachabilityMatrixUsingBFS() :
                    bfs.BuildReachabilityMatrixFromListUsingBFS(graph.GetAdjacencyList());
            }
            else
            {
                DFS dfs = new DFS(graph);
                int[][] reachabilityMatrix = useMatrix ?
                    dfs.BuildReachabilityMatrixUsingDFS() :
                    dfs.BuildReachabilityMatrixFromListUsingDFS(graph.GetAdjacencyList());
            }

            stopwatch.Stop();
            totalTime += stopwatch.ElapsedMilliseconds;
        }

        return totalTime / Trials;
    }
}
