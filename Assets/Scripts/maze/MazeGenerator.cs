using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace maze
{
    public class MazeGenerator : MonoBehaviour
    {
        public int width;
        public int height;
        public TileBase wallTile;
        public TileBase pathTile;
        private bool[,] _grid;
        private Tilemap _tilemap;

        private void Start()
        {
            _tilemap = GetComponent<Tilemap>();
            InitializeGrid();
            GenerateMaze();
        }

        private void InitializeGrid()
        {
            _grid = new bool[width, height];
        }

        private void GenerateMaze()
        {
            // Set all cells as walls
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _grid[x, y] = true;
                    _tilemap.SetTile(new Vector3Int(x, y, 0), wallTile);
                }
            }

            Stack<Vector2Int> stack = new Stack<Vector2Int>();
            Vector2Int startCell = new Vector2Int(0, 0);
            stack.Push(startCell);
            _grid[startCell.x, startCell.y] = false; // Mark the start cell as a path
            _tilemap.SetTile(new Vector3Int(startCell.x, startCell.y, 0), pathTile);

            while (stack.Count > 0)
            {
                Vector2Int currentCell = stack.Peek();
                List<Vector2Int> unvisitedNeighbors = GetUnvisitedNeighbors(currentCell);

                if (unvisitedNeighbors.Count > 0)
                {
                    int randomIndex = Random.Range(0, unvisitedNeighbors.Count);
                    Vector2Int nextCell = unvisitedNeighbors[randomIndex];
                    _grid[nextCell.x, nextCell.y] = false; // Mark the next cell as a path
                    _tilemap.SetTile(new Vector3Int(nextCell.x, nextCell.y, 0), pathTile);
                    RemoveWall(currentCell, nextCell);
                    stack.Push(nextCell);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        private List<Vector2Int> GetUnvisitedNeighbors(Vector2Int cell)
        {
            List<Vector2Int> neighbors = new List<Vector2Int>();

            // Add the neighbors of the current cell that are within the grid and are walls
            if (cell.x > 1 && _grid[cell.x - 2, cell.y])
            {
                neighbors.Add(new Vector2Int(cell.x - 2, cell.y));
            }

            if (cell.x < width - 2 && _grid[cell.x + 2, cell.y])
            {
                neighbors.Add(new Vector2Int(cell.x + 2, cell.y));
            }

            if (cell.y > 1 && _grid[cell.x, cell.y - 2])
            {
                neighbors.Add(new Vector2Int(cell.x, cell.y - 2));
            }

            if (cell.y < height - 2 && _grid[cell.x, cell.y + 2])
            {
                neighbors.Add(new Vector2Int(cell.x, cell.y + 2));
            }

            return neighbors;
        }

        private void RemoveWall(Vector2Int currentCell, Vector2Int nextCell)
        {
            int wallX = currentCell.x + (nextCell.x - currentCell.x) / 2;
            int wallY = currentCell.y + (nextCell.y - currentCell.y) / 2;
            _grid[wallX, wallY] = false; // Mark the wall between the current cell and the next cell as a path
            _tilemap.SetTile(new Vector3Int(wallX, wallY, 0), pathTile);
        }
    }
}