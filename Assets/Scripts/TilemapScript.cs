using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Utils;

public class TilemapScript : MonoBehaviour
{
    private GameMap<bool> _gameMap = GameMap<bool>.GetInstance();
    private Tilemap _tilemap;

    private void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        DiscoverMap(0, 0);
    }

    // Agrega recursivamente todas las celdas en las que se puede
    // caminar a una clase GameMap
    private bool DiscoverMap(int x, int y)
    {
        // Si la posicion ya se agrego, romper la recursion
        if (_gameMap.Has(x, y))
        {
            return true;
        }

        var position = new Vector3Int(x, y, 0);
        // Verificar que la celda exista
        if (_tilemap.HasTile(position))
        {
            var tile = _tilemap.GetTile(position);
            // Agregar celda a la clase GameMap
            _gameMap.Add(position, true);

            // Descubrir celdas alrededor de la celda actual recursivamente
            foreach (var (nextX, nextY) in TilePosition.neighbourTiles(position))
            {
                DiscoverMap(nextX, nextY);
            }
        }

        return false;
    }

}
