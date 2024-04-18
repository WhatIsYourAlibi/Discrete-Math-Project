namespace Adjacency_matrix_using_BFS_DFS;

public class Graph
{
    private int[][] _adjacencyMatrix;
    private List<int>[] _adjacencyList;
    private int _vertices;
    private bool _isMatrix;

    public Graph(int vertices)
    {
        this._vertices = vertices;
        _adjacencyMatrix = new int[vertices][];
        for (int i = 0; i < vertices; i++)
        {
            _adjacencyMatrix[i] = new int[vertices];
        }
        _adjacencyList = new List<int>[vertices];
        for (int i = 0; i < vertices; ++i)
            _adjacencyList[i] = new List<int>();
        _isMatrix = true;
    }

    public void AddEdge(int v1, int v2)
    {
        if (v1 >= 0 && v2 >= 0 && v1 < _vertices && v2 < _vertices && v1 != v2)
        {
            if (_isMatrix)
            {
                _adjacencyMatrix[v1][v2] = 1;
                _adjacencyMatrix[v2][v1] = 1;
            }
            else
            {
                _adjacencyList[v1].Add(v2);
                _adjacencyList[v2].Add(v1);
            }
        }
    }

    public void RemoveEdge(int v1, int v2)
    {
        if (v1 >= 0 && v2 >= 0 && v1 < _vertices && v2 < _vertices && v1 != v2)
        {
            if (_isMatrix)
            {
                _adjacencyMatrix[v1][v2] = 0;
                _adjacencyMatrix[v2][v1] = 0;
            }
            else
            {
                _adjacencyList[v1].Remove(v2);
                _adjacencyList[v2].Remove(v1);
            }
        }
    }

    public int[][] GetAdjacencyMatrix()
    {
        if (!_isMatrix)
        {
            ConvertToMatrix();
        }
        return _adjacencyMatrix;
    }

    public List<int>[] GetAdjacencyList()
    {
        if (_isMatrix)
        {
            ConvertToList();
        }
        return _adjacencyList;
    }

    private void ConvertToMatrix()
    {
        _adjacencyMatrix = new int[_vertices][];
        for (int i = 0; i < _vertices; i++)
        {
            _adjacencyMatrix[i] = new int[_vertices];
            foreach (int j in _adjacencyList[i])
            {
                _adjacencyMatrix[i][j] = 1;
            }
        }
        _isMatrix = true;
    }

    private void ConvertToList()
    {
        _adjacencyList = new List<int>[_vertices];
        for (int i = 0; i < _vertices; i++)
        {
            _adjacencyList[i] = new List<int>();
            for (int j = 0; j < _vertices; j++)
            {
                if (_adjacencyMatrix[i][j] == 1)
                {
                    _adjacencyList[i].Add(j);
                }
            }
        }
        _isMatrix = false;
    }
}