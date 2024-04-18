namespace Adjacency_matrix_using_BFS_DFS;

public class BFS
{
    private Graph _graph;

    public BFS(Graph graph)
    {
        _graph = graph;
    }

    public int[][] BuildReachabilityMatrixUsingBFS()
    {
        int vertices = _graph.GetVerticesCount();
        int[][] reachabilityMatrix = new int[vertices][];
        for (int i = 0; i < vertices; i++)
        {
            reachabilityMatrix[i] = new int[vertices];
        }

        for (int i = 0; i < vertices; i++)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visitedVertices = new bool[vertices];

            queue.Enqueue(i);
            visitedVertices[i] = true;

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();

                foreach (int neighbor in _graph.GetNeighbors(currentVertex))
                {
                    if (!visitedVertices[neighbor])
                    {
                        queue.Enqueue(neighbor);
                        visitedVertices[neighbor] = true;
                        reachabilityMatrix[i][neighbor] = 1;
                    }
                }
            }
        }
        
        return reachabilityMatrix;
    }
    
    public int[][] BuildReachabilityMatrixFromListUsingBFS(List<int>[] adjacencyList)
    {
        int vertices = adjacencyList.Length;
        int[][] reachabilityMatrix = new int[vertices][];
        
        for (int i = 0; i < vertices; i++)
        {
            reachabilityMatrix[i] = new int[vertices];
        }

        for (int i = 0; i < vertices; i++)
        {
            Queue<int> queue = new Queue<int>();
            bool[] visitedVertices = new bool[vertices];

            queue.Enqueue(i);
            visitedVertices[i] = true;

            while (queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();

                foreach (int neighbor in adjacencyList[currentVertex])
                {
                    if (!visitedVertices[neighbor])
                    {
                        queue.Enqueue(neighbor);
                        visitedVertices[neighbor] = true;
                        reachabilityMatrix[i][neighbor] = 1;
                    }
                }
            }
        }
        return reachabilityMatrix;
    }
}