using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Reflection;

public class TileTest : MonoBehaviour
{
    public Camera main;
    public Tilemap tilemap;
    public Vector3 offset = new Vector3(0f, 0.1f, 0);
    public TileBase originTile;
    public TileBase destinationTile;

    [SerializeField] private SpriteRenderer playerSprite;

    Vector3Int tilePosition;

    public DijTest scanArea;

    private bool _isPlayerSelected;
    public float moveSpeed = 5f;

    private Dictionary<Tilemap, Vector3Int> _previousPosition = new Dictionary<Tilemap, Vector3Int>();
    private Dictionary<Tilemap, Vector3Int> _origin = new Dictionary<Tilemap, Vector3Int>();
    private Dictionary<Tilemap, Vector3Int> _goal = new Dictionary<Tilemap, Vector3Int>();


    private Dictionary<string, Action> _actions = new Dictionary<string, Action>();




    private void Start()
    {
        _previousPosition[tilemap] = new Vector3Int(-1, -1, 0);
        _origin[tilemap] = new Vector3Int(-1, -1, 0);
    }

    private void Update()
    {
        SelectTile();
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit && hit.collider.GetComponent<SpriteRenderer>() == playerSprite)
            {
                Debug.Log(hit.collider.gameObject.name);
                _origin[tilemap] = tilePosition;
            }
            else
            {
                DetectTileClick(isOrigin: true);
            }
            _isPlayerSelected = true;
            ShowMovementArea();
        }


    }

    private void SelectTile()
    {
        Vector3 mousePosition = main.ScreenToWorldPoint(Input.mousePosition);
        tilePosition = tilemap.WorldToCell(mousePosition);
        tilePosition.z = 0;

        if (tilePosition != _previousPosition[tilemap])
        {
            if (tilemap.HasTile(tilePosition))
            {
                tilemap.SetTransformMatrix(tilePosition, Matrix4x4.TRS(offset, Quaternion.Euler(0, 0, 0), Vector3.one));
            }
            if (tilemap.HasTile(_previousPosition[tilemap]))
            {
                tilemap.SetTransformMatrix(_previousPosition[tilemap], Matrix4x4.identity);
            }
            _previousPosition[tilemap] = tilePosition;
        }
    }

    private void DetectTileClick(bool isOrigin)
    {
        Vector3 mousePosition = main.ScreenToWorldPoint(Input.mousePosition);
        tilePosition = tilemap.WorldToCell(mousePosition);
        tilePosition.z = 0;

        TileBase newTile = isOrigin ? originTile : destinationTile; // si es true agarra el primero si es false agarra el otro
        Dictionary<Tilemap, Vector3Int> selectedDictionary = isOrigin ? _origin : _goal;

        if (tilemap.HasTile(tilePosition))
        {
            var oldTile = tilemap.GetTile(tilePosition);
            tilemap.SetTile(tilePosition, newTile);

            if (selectedDictionary.ContainsKey(tilemap))
            {
                tilemap.SetTile(selectedDictionary[tilemap], oldTile);
            }
            selectedDictionary[tilemap] = tilePosition;

        }
    }
    private void ShowMovementArea()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int cellPosition = tilemap.WorldToCell(new Vector3(mousePosition.x, mousePosition.y, 0f));
        Vector3 worldPosition = tilemap.CellToWorld(cellPosition) + new Vector3(1 / 2f, 1 / 2f, 0f);
        Debug.Log("Clicked on cell " + cellPosition + " at position " + worldPosition);
        if (_origin.ContainsKey(tilemap))
        {
            scanArea.Origin = _origin[tilemap];
        }
        else
        {
            scanArea.Origin = cellPosition;
        }
        scanArea.StartCoroutine(scanArea.FloodField(0.01f));
    }


}
