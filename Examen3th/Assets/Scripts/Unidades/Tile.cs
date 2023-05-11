using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Threading.Tasks;

public class Tile : MonoBehaviour
{
    [SerializeField] Camera main;
    [SerializeField] Grid grid;
    public Tilemap tileMap;
    public Tilemap araña;
    public Tilemap ogro;
    public Tilemap cosoFeo;
    public Tilemap Demonio;
    public Vector3 offset = new Vector3(0f, 0.02f, 0f);
    public TileBase originTile, destinyTile;

    [HideInInspector]
    public TileBase tb;

    private Dictionary<Tilemap, Vector3Int> _previousPosition = new Dictionary<Tilemap, Vector3Int>();
    private Dictionary<Tilemap, Vector3Int> _origin = new Dictionary<Tilemap, Vector3Int>();
    private Dictionary<Tilemap, Vector3Int> _goal = new Dictionary<Tilemap, Vector3Int>();

    [SerializeField] Araña scanArea;

    bool _isPlayerSelected = false;
    Vector3Int tilePosition;

    private void Start()
    {
        _previousPosition[tileMap] = new Vector3Int(-1, -1, 0);
    }


    private void Update()
    {
        if (!scanArea.IsPlayerSelected) SelectTile();

        if (Input.GetMouseButtonDown(0))
        {
            if (araña.HasTile(tilePosition))
            {

                scanArea.maxSteps = 30;
                DetectTileClick(isOrigin: true);
                scanArea.IsPlayerSelected = true;
                ShowMovementArea();
                DetectTileClick(isOrigin: false);

            }

            if (ogro.HasTile(tilePosition))
            {

                scanArea.maxSteps = 50;
                DetectTileClick(isOrigin: true);
                scanArea.IsPlayerSelected = true;
                ShowMovementArea();
                DetectTileClick(isOrigin: false);

            }

            if (cosoFeo.HasTile(tilePosition))
            {

                scanArea.maxSteps = 60;
                DetectTileClick(isOrigin: true);
                scanArea.IsPlayerSelected = true;
                ShowMovementArea();
                DetectTileClick(isOrigin: false);

            }

            if (Demonio.HasTile(tilePosition))
            {

                scanArea.maxSteps = 60;
                DetectTileClick(isOrigin: true);
                scanArea.IsPlayerSelected = true;
                ShowMovementArea();
                DetectTileClick(isOrigin: false);

            }
        }
        if (scanArea.IsPlayerSelected)
        {
            DetectTileClick(isOrigin: false);
            scanArea.DrawPath(tilePosition);
        }
        if (scanArea.IsPlayerSelected && Input.GetKeyDown(KeyCode.Return)) scanArea.MovePlayer();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scanArea.IsPlayerSelected = false;
            scanArea.ClearTiles();
        }

    }


    private void SelectTile()
    {
        Vector3 mousePosition = main.ScreenToWorldPoint(Input.mousePosition);
        tilePosition = tileMap.WorldToCell(mousePosition);
        tilePosition.z = 0;

        if (tilePosition != _previousPosition[tileMap])
        {
            if (tileMap.HasTile(tilePosition))
            {
                tileMap.SetTransformMatrix(tilePosition, Matrix4x4.TRS(offset, Quaternion.Euler(0, 0, 0), Vector3.one));
            }
            if (tileMap.HasTile(_previousPosition[tileMap]))
            {
                tileMap.SetTransformMatrix(_previousPosition[tileMap], Matrix4x4.identity);
            }
            _previousPosition[tileMap] = tilePosition;
        }
    }


    private void DetectTileClick(bool isOrigin)
    {
        Vector3 mousePos = main.ScreenToWorldPoint(Input.mousePosition);
        tilePosition = tileMap.WorldToCell(mousePos);
        tilePosition.z = 0;

        TileBase newTile = isOrigin ? originTile : destinyTile;
        Dictionary<Tilemap, Vector3Int> selectedDictionary = isOrigin ? _origin : _goal;

        if (tileMap.HasTile(tilePosition))
        {
            var oldTile = tileMap.GetTile(tilePosition);
            selectedDictionary[tileMap] = tilePosition;
        }
    }

    private void ShowMovementArea()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = grid.WorldToCell(new Vector3(mousePosition.x, mousePosition.y, 0f));
        Vector3 worldPosition = grid.CellToWorld(cellPosition) + new Vector3(1 / 2f, 1 / 2f, 0f);
        Debug.Log("Clicked on cell " + cellPosition + " at position " + worldPosition);
        scanArea.Origin = cellPosition;
        scanArea.StartScan();
    }
}
