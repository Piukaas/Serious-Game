using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Maze
{
    public class MazeSolver : MonoBehaviour
    {
        public Tilemap tilemap;
        public Vector2Int startPoint;
        public Vector2Int endPoint;
        public TileBase highlightTile;

        private Dictionary<Vector2Int, Node> _grid;
        private List<Node> _openList;
        private List<Node> _closedList;
        
        private readonly Vector2Int[] _directions =
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.right,
            Vector2Int.left
        };

        public void Solve()
        {
            InitializeGrid();
            FindPath();
        }

        private void InitializeGrid()
        {
            _grid = new Dictionary<Vector2Int, Node>();

            BoundsInt bounds = tilemap.cellBounds;

            // Note: this assumes that the start point always has a lower x coordinate than the end point.
            for (int x = startPoint.x; x <= endPoint.x; x++)
            {
                for (int y = bounds.yMin; y < bounds.yMax; y++)
                {
                    Vector2Int pos = new Vector2Int(x, y);
                    TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));

                    if (tile == null || tile.name == "Path")
                    {
                        _grid[pos] = new Node(pos, true);
                    }
                    else
                    {
                        _grid[pos] = new Node(pos, false);
                    }
                }
            }
        }

        private void FindPath()
        {
            Node startNode = _grid[startPoint];
            Node endNode = _grid[endPoint];

            _openList = new List<Node> {startNode};
            _closedList = new List<Node>();

            startNode.GCost = 0;
            startNode.HCost = HeuristicCostEstimate(startNode, endNode);

            while (_openList.Count > 0)
            {
                Node currentNode = GetLowestFCostNode();

                if (currentNode == endNode)
                {
                    // Found the path!
                    RetracePath(startNode, endNode);
                    break;
                }

                _openList.Remove(currentNode);
                _closedList.Add(currentNode);

                foreach (Node neighbor in GetNeighbors(currentNode))
                {
                    if (!neighbor.IsWalkable || _closedList.Contains(neighbor))
                        continue;

                    float tentativeGCost = currentNode.GCost + 1f; // Assuming the cost between adjacent cells is 1

                    if (tentativeGCost < neighbor.GCost || !_openList.Contains(neighbor))
                    {
                        neighbor.GCost = tentativeGCost;
                        neighbor.HCost = HeuristicCostEstimate(neighbor, endNode);
                        neighbor.Parent = currentNode;

                        if (!_openList.Contains(neighbor))
                            _openList.Add(neighbor);
                    }
                }
            }
        }

        private float HeuristicCostEstimate(Node from, Node to)
        {
            // Manhattan distance heuristic
            return Mathf.Abs(from.Position.x - to.Position.x) + Mathf.Abs(from.Position.y - to.Position.y);
        }

        private Node GetLowestFCostNode()
        {
            Node lowestFCostNode = _openList[0];

            for (int i = 1; i < _openList.Count; i++)
            {
                Node node = _openList[i];
                if (node.FCost < lowestFCostNode.FCost || (node.FCost == lowestFCostNode.FCost && node.HCost < lowestFCostNode.HCost))
                {
                    lowestFCostNode = node;
                }
            }

            return lowestFCostNode;
        }

        private List<Node> GetNeighbors(Node node)
        {
            List<Node> neighbors = new List<Node>();

            foreach (Vector2Int direction in _directions)
            {
                Vector2Int neighborPosition = node.Position + direction;

                if (_grid.TryGetValue(neighborPosition, out var value))
                {
                    neighbors.Add(value);
                }
            }

            return neighbors;
        }

        private void RetracePath(Node startNode, Node endNode)
        {
            Node currentNode = endNode;

            while (currentNode != startNode)
            {
                Vector2Int pos = currentNode.Position;
                tilemap.SetTile(new Vector3Int(pos.x, pos.y, 0), highlightTile);
                currentNode = currentNode.Parent;
            }
        }

        private class Node
        {
            public Vector2Int Position;
            public readonly bool IsWalkable;
            public float GCost;
            public float HCost;
            public Node Parent;

            public float FCost => GCost + HCost;

            public Node(Vector2Int position, bool isWalkable)
            {
                Position = position;
                IsWalkable = isWalkable;
            }
        }
    }
}