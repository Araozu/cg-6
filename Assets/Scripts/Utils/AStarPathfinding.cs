using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// https://blog.theknightsofunity.com/pathfinding-on-a-hexagonal-grid-a-algorithm/
namespace Utils
{
    /*
    /// <summary>
    /// Implementation of A* pathfinding algorithm.
    /// </summary>
    public class AStarPathfinding
    {
        /// <summary>
        /// Finds path from given start point to end point. Returns an empty list if the path couldn't be found.
        /// </summary>
        /// <param name="startPoint">Start tile.</param>
        /// <param name="endPoint">Destination tile.</param>
        public static List<MapTile> FindPath(MapTile startPoint, MapTile endPoint)
        {
            List<MapTile> openPathTiles = new List<MapTile>();
            List<MapTile> closedPathTiles = new List<MapTile>();

            // Prepare the start tile.
            MapTile currentMapTile = startPoint;

            currentMapTile.g = 0;
            currentMapTile.h = GetEstimatedPathCost(startPoint.position, endPoint.position);

            // Add the start tile to the open list.
            openPathTiles.Add(currentMapTile);

            while (openPathTiles.Count != 0)
            {
                // Sorting the open list to get the tile with the lowest F.
                openPathTiles = openPathTiles.OrderBy(x => x.F).ThenByDescending(x => x.g).ToList();
                currentMapTile = openPathTiles[0];

                // Removing the current tile from the open list and adding it to the closed list.
                openPathTiles.Remove(currentMapTile);
                closedPathTiles.Add(currentMapTile);

                int g = currentMapTile.g + 1;

                // If there is a target tile in the closed list, we have found a path.
                if (closedPathTiles.Contains(endPoint))
                {
                    break;
                }

                // Investigating each adjacent tile of the current tile.
                foreach (MapTile adjacentTile in currentMapTile.adjacentTiles)
                {
                    // Ignore not walkable adjacent tiles.
                    if (adjacentTile.isObstacle)
                    {
                        continue;
                    }

                    // Ignore the tile if it's already in the closed list.
                    if (closedPathTiles.Contains(adjacentTile))
                    {
                        continue;
                    }

                    // If it's not in the open list - add it and compute G and H.
                    if (!(openPathTiles.Contains(adjacentTile)))
                    {
                        adjacentTile.g = g;
                        adjacentTile.h = GetEstimatedPathCost(adjacentTile.position, endPoint.position);
                        openPathTiles.Add(adjacentTile);
                    }
                    // Otherwise check if using current G we can get a lower value of F, if so update it's value.
                    else if (adjacentTile.F > g + adjacentTile.h)
                    {
                        adjacentTile.g = g;
                    }
                }
            }

            List<MapTile> finalPathTiles = new List<MapTile>();

            // Backtracking - setting the final path.
            if (closedPathTiles.Contains(endPoint))
            {
                currentMapTile = endPoint;
                finalPathTiles.Add(currentMapTile);

                for (int i = endPoint.g - 1; i >= 0; i--)
                {
                    currentMapTile = closedPathTiles.Find(x => x.g == i && currentMapTile.adjacentTiles.Contains(x));
                    finalPathTiles.Add(currentMapTile);
                }

                finalPathTiles.Reverse();
            }

            return finalPathTiles;
        }

        /// <summary>
        /// Returns estimated path cost from given start position to target position of hex tile using Manhattan distance.
        /// </summary>
        /// <param name="startPosition">Start position.</param>
        /// <param name="targetPosition">Destination position.</param>
        protected static int GetEstimatedPathCost(Vector3Int startPosition, Vector3Int targetPosition)
        {
            return Mathf.Max(Mathf.Abs(startPosition.z - targetPosition.z),
                Mathf.Max(Mathf.Abs(startPosition.x - targetPosition.x),
                    Mathf.Abs(startPosition.y - targetPosition.y)));
        }
    }
    */
}