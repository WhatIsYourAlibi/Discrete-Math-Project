namespace Adjacency_matrix_using_BFS_DFS;

public class Program
{
    public static void Main()
    {
        // Create a new graph with 5 vertices
        Graph graph = new Graph(5);

        // Adding edges
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);

        // Display the adjacency matrix
        Console.WriteLine("Adjacency Matrix:");
        DisplayMatrix(graph.GetAdjacencyMatrix());

        // Display the adjacency list
        Console.WriteLine("\nAdjacency List:");
        DisplayList(graph.GetAdjacencyList());

        // Remove an edge
        graph.RemoveEdge(1, 3);

        // Display the adjacency matrix after removing an edge
        Console.WriteLine("\nAdjacency Matrix after removing an edge between 1 and 3:");
        DisplayMatrix(graph.GetAdjacencyMatrix());

        // Display the adjacency list after removing an edge
        Console.WriteLine("\nAdjacency List after removing an edge between 1 and 3:");
        DisplayList(graph.GetAdjacencyList());
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