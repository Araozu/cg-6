using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    // Metodos de ayuda para manejar las posiciones de las celdas
    public class TilePosition
    {
        // https://github.com/Unity-Technologies/2d-extras/issues/69#issuecomment-684190243
        public Vector3Int UnityCellToCube(Vector3Int cell)
        {
            var yCell = cell.x; 
            var xCell = cell.y;
            var x = yCell - (xCell - (xCell & 1)) / 2;
            var z = xCell;
            var y = -x - z;
            return new Vector3Int(x, y, z);
        }
        public Vector3Int CubeToUnityCell(Vector3Int cube)
        {
            var x = cube.x;
            var z = cube.z;
            var col = x + (z - (z & 1)) / 2;
            var row = z;

            return new Vector3Int(col, row,  0);
        }

        public static IEnumerable<(int, int)> neighbourTiles(int x, int y)
        {
            yield return TopLeft(x, y);
            yield return TopRight(x, y);
            yield return Right(x, y);
            yield return BottomRight(x, y);
            yield return BottomLeft(x, y);
            yield return Left(x, y);
        }

        // Devuelve las posiciones de las celdas alrededor de una
        public static IEnumerable<(int, int)> neighbourTiles(Vector3Int vector)
        {
            return neighbourTiles(vector.x, vector.y);
        }

        // Celda arriba derecha
        public static (int, int) TopRight(int x, int y)
        {
            if (x % 2 == 0)
            {
                // 4,2 -> 4,3
                return (x, y + 1);
            }
            else
            {
                // 0,-1 -> 1, 0
                return (x + 1, y + 1);
            }
        }

        // Celda arriba izq
        public static (int, int) TopLeft(int x, int y)
        {
            if (x % 2 == 0)
            {
                // 4,2 -> 3, 3
                return (x - 1, y + 1);
            }
            else
            {
                // 1,1 -> 1,2
                return (x, y + 1);
            }
        }

        // Celda derecha
        public static (int, int) Right(int x, int y)
        {
            return (x + 1, y);
        }

        // Celda izq
        public static (int, int) Left(int x, int y)
        {
            return (x - 1, y);
        }

        // Celda abajo derecha
        public static (int, int) BottomRight(int x, int y)
        {
            if (x % 2 == 0)
            {
                // 4,2 -> 4,1
                return (x, y - 1);
            }
            else
            {
                // 4,1 -> 5,0
                return (x + 1, y - 1);
            }
        }

        // Celda abajo izq
        public static (int, int) BottomLeft(int x, int y)
        {
            if (x % 2 == 0)
            {
                // 4,2 -> 3,1
                return (x - 1, y - 1);
            }
            else
            {
                // 4,1 -> 4,0
                return (x, y - 1);
            }
        }
    }
}