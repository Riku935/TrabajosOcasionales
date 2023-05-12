using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Threading.Tasks;
using static UnityEditor.PlayerSettings;

public class TileSelector : MonoBehaviour
{
    [SerializeField] Camera main;
    [SerializeField] Grid grid;
    public Tilemap tileMap;
    public Tilemap ogro;
    public Tilemap demonio;
    public Tilemap cosoFeo;
    public Tilemap araña;
    public Vector3 offset = new Vector3(0f, 0.02f, 0f);
    public TileBase originTile, destinyTile;

    [HideInInspector]
    public TileBase tb;

    private Dictionary<Tilemap, Vector3Int> _previousPosition = new Dictionary<Tilemap, Vector3Int>();
    private Dictionary<Tilemap, Vector3Int> _origin = new Dictionary<Tilemap, Vector3Int>();
    private Dictionary<Tilemap, Vector3Int> _goal = new Dictionary<Tilemap, Vector3Int>();

    [SerializeField] Ogro ogro2;   //Infanteria
    [SerializeField] Demonio demonio2; //Tank
    [SerializeField] CosoFeo cosoFeo2;  //Reco
    [SerializeField] Araña araña2;  //Caballeria

    bool _isPlayerSelected = false;
    Vector3Int tilePosition;

    private void Start()
    {
        _previousPosition[tileMap] = new Vector3Int(-1, -1, 0);
    }


    private void Update()
    {
        if (!ogro2.IsPlayerSelected) SelectTile();

        if (Input.GetMouseButtonDown(0))
        {
            if (ogro.HasTile(tilePosition))
            {
               
                ogro2.maxSteps = 30;
                DetectTileClick(isOrigin: true);
                ogro2.IsPlayerSelected = true;
                ShowMovementArea();
                DetectTileClick(isOrigin: false);
                 
            }
            
            if (demonio.HasTile(tilePosition))
            {
               
                    demonio2.maxSteps = 50;
                    DetectTileClick(isOrigin: true);
                    demonio2.IsPlayerSelected = true;
                    ShowMovementArea();
                    DetectTileClick(isOrigin: false);
              
            }

            if (cosoFeo.HasTile(tilePosition))
            {

                cosoFeo2.maxSteps = 60;
                DetectTileClick(isOrigin: true);
                cosoFeo2.IsPlayerSelected = true;
                ShowMovementArea();
                DetectTileClick(isOrigin: false);

            }

            if (araña.HasTile(tilePosition))
            {

                araña2.maxSteps = 60;
                DetectTileClick(isOrigin: true);
                araña2.IsPlayerSelected = true;
                ShowMovementArea();
                DetectTileClick(isOrigin: false);

            }
        }

        if (ogro2.IsPlayerSelected)
        {
            DetectTileClick(isOrigin: false);
            ogro2.DrawPath(tilePosition);
           
        }

        if (demonio2.IsPlayerSelected)
        {
            DetectTileClick(isOrigin: false);
           
            demonio2.DrawPath(tilePosition);
           
        }

        if (cosoFeo2.IsPlayerSelected)
        {
            DetectTileClick(isOrigin: false);
            
            cosoFeo2.DrawPath(tilePosition);
           
        }

        if (araña2.IsPlayerSelected)
        {
            DetectTileClick(isOrigin: false);
           
            araña2.DrawPath(tilePosition);
        }

        if (ogro2.IsPlayerSelected  && Input.GetKeyDown(KeyCode.Return))
        {
            DetectTileClick(isOrigin: false);
            ogro2.MovePlayer();
           
        }

        if (demonio2.IsPlayerSelected && Input.GetKeyDown(KeyCode.Return))
        {
            DetectTileClick(isOrigin: false);
            demonio2.MovePlayer();
            
        }

        if (cosoFeo2.IsPlayerSelected && Input.GetKeyDown(KeyCode.Return))
        {
            DetectTileClick(isOrigin: false);
            cosoFeo2.MovePlayer();
           
        }

        if (araña2.IsPlayerSelected && Input.GetKeyDown(KeyCode.Return))
        {
            DetectTileClick(isOrigin: false);
            araña2.MovePlayer();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ogro2.IsPlayerSelected = false;
            ogro2.ClearTiles();

            demonio2.IsPlayerSelected = false;
            demonio2.ClearTiles();

            cosoFeo2.IsPlayerSelected = false;
            cosoFeo2.ClearTiles();

            araña2.IsPlayerSelected = false;
            araña2.ClearTiles();
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
        ogro2.Origin = cellPosition;
        ogro2.StartScan();

        demonio2.Origin = cellPosition;
        demonio2.StartScan();

        cosoFeo2.Origin = cellPosition;
        cosoFeo2.StartScan();

        araña2.Origin = cellPosition;
        araña2.StartScan();
    }


}
