# Graph Reachability Matrix Project

## Overview
This project explores the implementation and analysis of the Breadth-First Search (BFS) and Depth-First Search (DFS) algorithms for constructing reachability matrices in undirected graphs. The study evaluates the impact of graph representation on the performance of these algorithms across a range of graph sizes and densities.

## Algorithms
- **BFS**: An algorithm for traversing or searching tree or graph data structures, starting at the root node and exploring all neighbor nodes at the present depth prior to moving on to nodes at the next depth level.
- **DFS**: An algorithm for traversing or searching tree or graph data structures by exploring as far as possible along each branch before backtracking.

## Project Structure
- `BFS.cs`: Contains the BFS algorithm implementation using adjacency matrices and lists.
- `DFS.cs`: Contains the DFS algorithm implementation using adjacency matrices and lists.
- `Graph.cs`: Defines the graph data structure with methods for adding and removing edges.
- `GraphGenerator.cs`: Responsible for generating random graphs based on specified sizes and densities.
- `Program.cs`: The main entry point of the application where the experiments are orchestrated.

## Experimental Design
Experiments were carried out to determine the execution time of BFS and DFS algorithms for graphs varying in size (from 20 to 200 vertices) and density. A 100 trials per graph configuration were executed to obtain a statistically significant average time performance.

## Results
The results are tabulated and graphically presented in the project report, highlighting the comparative performance analysis of the BFS and DFS algorithms based on different graph representations.

## Usage
To run the experiments, ensure you have the required development environment set up and execute the `Program.cs` file. The results will be output to the console or can be directed to an output file of your choice.

## Contributions
The project is a result of collaborative efforts:
- **Emir**: Focused on algorithm implementation and optimization.
- **Mykhailo**: Led the experimental design, data collection, and analysis.

## License
This project is open-source and available under the [MIT License](LICENSE).
