namespace Adjacency_matrix_using_BFS_DFS;

public class DFS
{
    private Graph _graph;

    public DFS(Graph graph)
    {
        _graph = graph;
    }

    public int[][] BuildReachabilityMatrixUsingDFS()
    {
        int vertices = _graph.GetVerticesCount();
        int[][] reachabilityMatrix = new int[vertices][];

        for (int i = 0; i < vertices; i++)
        {
            reachabilityMatrix[i] = new int[vertices];
        }

        for (int i = 0; i < vertices; i++)
        {
            Stack<int> stack = new Stack<int>();
            bool[] visitedVertices = new bool[vertices];

            stack.Push(i);
            visitedVertices[i] = true;

            while (stack.Count > 0)
            {
                int currentVertex = stack.Pop();

                foreach (int neighbor in _graph.GetNeighbors(currentVertex))
                {
                    if (!visitedVertices[neighbor])
                    {
                        stack.Push(neighbor);
                        visitedVertices[neighbor] = true;
                        reachabilityMatrix[i][neighbor] = 1; 
                    }
                }
            }
        }

        return reachabilityMatrix;
    }
    
    public int[][] BuildReachabilityMatrixFromListUsingDFS(List<int>[] adjacencyList)
    {
        int vertices = adjacencyList.Length;
        int[][] reachabilityMatrix = new int[vertices][];
        
        for (int i = 0; i < vertices; i++)
        {
            reachabilityMatrix[i] = new int[vertices];
        }

        for (int i = 0; i < vertices; i++)
        {
            Stack<int> stack = new Stack<int>();
            bool[] visitedVertices = new bool[vertices];

            stack.Push(i);
            visitedVertices[i] = true;

            while (stack.Count > 0)
            {
                int currentVertex = stack.Pop();

                foreach (int neighbor in adjacencyList[currentVertex])
                {
                    if (!visitedVertices[neighbor])
                    {
                        stack.Push(neighbor);
                        visitedVertices[neighbor] = true;
                        reachabilityMatrix[i][neighbor] = 1;
                    }
                }
            }
        }

        return reachabilityMatrix;
    }
    
}