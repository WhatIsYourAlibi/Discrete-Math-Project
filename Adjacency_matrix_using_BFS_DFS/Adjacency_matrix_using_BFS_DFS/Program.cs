namespace Adjacency_matrix_using_BFS_DFS;

public class Program
{
    public static void Main()
    {
        Graph randomGraph = GraphGenerator.GenerateRandomGraph(10, 0.5);
        Console.WriteLine("Adjacency Matrix:");
        DisplayMatrix(randomGraph.GetAdjacencyMatrix());
        Console.WriteLine("\nAdjacency List:");
        DisplayList(randomGraph.GetAdjacencyList());
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