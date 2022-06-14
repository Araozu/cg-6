using UnityEngine;
using UnityEngine.Tilemaps;
using Utils;

// Controla el comportamiento del jugador
public class CharacterScript : MonoBehaviour
{
    private Transform _transform;
    private GameMap<bool> _gameMap = GameMap<bool>.GetInstance();

    public Camera mainCamera;
    public Tilemap tiles;
    public Tile moveIndicator;

    private Vector3Int _currentLocation;
    private Vector3Int _previousTileLocation;

    private Vector3Int _characterPosition;

    private void Start()
    {
        _transform = GetComponent<Transform>();

        // Get initial character position
        var mp = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _characterPosition = tiles.WorldToCell(mp);
        Debug.Log(mp);
        Debug.Log("Character position:" + _characterPosition);
    }

    private void Update()
    {
        HighlightTile();

        // Si se hace click mover
        if (Input.GetMouseButtonDown(0))
        {
            Move();
        }
    }

    // Constantemente resaltar la celda encima del mouse
    private void HighlightTile()
    {
        var mp = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _currentLocation = tiles.WorldToCell(mp);
        _currentLocation.z = 3;

        // If the tile is not in the map, return
        if (!_gameMap.Has(_currentLocation.x, _currentLocation.y))
        {
            tiles.SetTile(_previousTileLocation, null);
            _previousTileLocation = _currentLocation;
            return;
        }

        if (_currentLocation != _previousTileLocation)
        {
            tiles.SetTile(_currentLocation, moveIndicator);
            tiles.SetTile(_previousTileLocation, null);
            _previousTileLocation = _currentLocation;
        }
    }

    // Mueve el personaje a la celda debajo del mouse
    private void Move()
    {
        // TODO: Pathfinding, follow a route
        // TODO: Allow movement greater than 1 tile at a time

        if (_gameMap.Has(_currentLocation.x, _currentLocation.y))
        {
            var worldPosition = tiles.CellToWorld(_currentLocation);
            transform.position = worldPosition;
        }
    }
}