using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    // Almacena las celdas que existen en el tilemap
    public class GameMap<T>
    {
        private static GameMap<T> _instance;

        public static GameMap<T> GetInstance()
        {
            if (_instance != null) return _instance;

            _instance = new GameMap<T>();
            return _instance;
        }

        private GameMap() {}

        private readonly Dictionary<(int, int), T> _dict = new();

        public void Add(int x, int y, T value)
        {
            _dict.Add((x, y), value);
        }

        // Agregar celda
        public void Add(Vector3Int position, T value)
        {
            Add(position.x, position.y, value);
        }

        public bool Has(int x, int y)
        {
            return _dict.ContainsKey((x, y));
        }

        // Revisar si existe una celda en esta posicion
        public bool Has(Vector3Int v)
        {
            return Has(v.x, v.y);
        }
    }
}
