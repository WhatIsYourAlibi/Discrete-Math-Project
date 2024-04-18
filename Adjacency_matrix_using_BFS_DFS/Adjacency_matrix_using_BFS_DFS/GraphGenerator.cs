namespace Adjacency_matrix_using_BFS_DFS;

public class GraphGenerator
{
    private static Random rand = new Random();

    public static Graph GenerateRandomGraph(int n, double density)
    {
        if (n < 1 || density < 0 || density > 1)
        {
            throw new ArgumentException("Invalid number of vertices or density.");
        }

        // Calculate the number of edges for the given density
        int maxEdges = n * (n - 1) / 2;
        int numberOfEdges = (int)(density * maxEdges);

        // Probability of an edge existing between any two vertices
        double p = 2.0 * numberOfEdges / (n * (n - 1));

        Graph graph = new Graph(n);

        // Generating edges
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (rand.NextDouble() < p)
                {
                    graph.AddEdge(i, j);
                }
            }
        }

        return graph;
    }
}