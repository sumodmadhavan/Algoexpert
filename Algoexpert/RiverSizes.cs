using System;
using System.Collections.Generic;

namespace Algoexpert
{
    public class RiverSizes
    {
        //Need practice
        public RiverSizes()
        {
        }
        public List<int> FindRiverSizers(int[,] matrix)
        {
            List<int> sizes = new List<int>();
            bool[,] visited = new bool[matrix.GetLength(0),matrix.GetLength(1)];
            //for rows
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                //for columns
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (visited[i,j])
                    {
                        continue;
                    }
                    TraverseNodes(i, j, matrix, visited, sizes);

                }
            }
            return sizes;
        }

        private void TraverseNodes(int i, int j, int[,] matrix, bool[,] visited, List<int> sizes)
        {
            int currentRiverSize = 0;
            List<int[]> nodestoexplore = new List<int[]>();
            nodestoexplore.Add(new int[] { i, j });
            while (nodestoexplore.Count>0)
            {
                int[] currentNode = nodestoexplore[nodestoexplore.Count - 1];
                nodestoexplore.Remove(currentNode);
                i = currentNode[0];
                j = currentNode[1];
                if (visited[i,j])
                {
                    continue;
                }
                visited[i, j] = true;
                if (matrix[i,j] == 0)
                {
                    continue;
                }
                currentRiverSize++;
                List<int[]> unvisitedNeighbours = GetUnvisitedNeighbours(i, j, matrix, visited);
                foreach (var neighbour in unvisitedNeighbours)
                {
                    nodestoexplore.Add(neighbour);
                }
                
            }
            if (currentRiverSize>0)
            {
                sizes.Add(currentRiverSize);
            }
        }

        private List<int[]> GetUnvisitedNeighbours(int i, int j, int[,] matrix, bool[,] visited)
        {
            List<int[]> unvisitedNeighbours = new List<int[]>();
            if (i>0 && !visited[i-1,j])
            {
                unvisitedNeighbours.Add(new int[] { i - 1, j });
            }
            if (i < matrix.GetLength(0)-1 && !visited[i+1,j])
            {
                unvisitedNeighbours.Add(new int[] { i+1, j});
            }
            if (j>0 && !visited[i,j-1])
            {
                unvisitedNeighbours.Add(new int[] { i, j-1 });
            }
            if (j<matrix.GetLength(1)-1 && !visited[i,j+1])
            {
                unvisitedNeighbours.Add(new int[] { i, j + 1 });
            }
            return unvisitedNeighbours;
        }

    }
}
