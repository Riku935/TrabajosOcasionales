using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Reflection;

public class TileSelector : MonoBehaviour
{
    public Camera main;
    public Tilemap tilemap;
    public Vector3 offSet = new Vector3 (0, 0.3f, 0);

    public TileBase originTile;
    public TileBase destinationTile;

    private Dictionary<Tilemap, Vector3Int> _previousPosition = new Dictionary<Tilemap, Vector3Int>();
    private Dictionary<Tilemap, Vector3Int> _origin = new Dictionary<Tilemap, Vector3Int>();
    private Dictionary<Tilemap, Vector3Int> _goal = new Dictionary<Tilemap, Vector3Int>();

    public Search floodFill;
    public DijkstraAlgorithm dijkstra;
    public HeuristicDijkstra heuristic;
    public Aalgorithm aAlgorithm;

    private enum AlgorithmType
    {
        FloodFill, Heuristic, A_Algorithm, Dijkstra
    }

    [SerializeField] private AlgorithmType _type;
    private Dictionary<string, Action> _actions = new Dictionary<string, Action>();

    private void Start()
    {
        _previousPosition[tilemap] = new Vector3Int(-1, -1, 0);
        _actions.Add("FloodFill", StartFloodFill); //Añades acciones al diccionario 
        _actions.Add("Heuristic", StartHeuristic);
        _actions.Add("A_Algorithm", StartA);
        _actions.Add("Dijkstra", StartDijkstra);
    }

    private void Update()
    {
        SelectTile();
        if(Input.GetMouseButton(0))
        {
            DetectTileClick(true);
        }
        else if(Input.GetMouseButton(1))
        {
            DetectTileClick(false);
        }
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if (_actions.TryGetValue(_type.ToString(), out Action action)) //Intenta buscar el nombre y si encuentra el nombre, ejecutas la accion
            {
                action(); //Ejecutas la accion
            }
        }
    }
    private void DetectTileClick(bool isOrigin)
    {
        Vector3 mousePosition = main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = tilemap.WorldToCell(mousePosition);
        tilePosition.z = 0;

        TileBase newTile = isOrigin ? originTile : destinationTile;
        Dictionary<Tilemap, Vector3Int> selectedDictionary = isOrigin ? _origin : _goal;

        if(tilemap.HasTile(tilePosition))
        {
            var oldTile = tilemap.GetTile(tilePosition);
            tilemap.SetTile(tilePosition, newTile);
            if (selectedDictionary.ContainsKey(tilemap))
            {
                tilemap.SetTile(selectedDictionary[tilemap], oldTile);
            }
            //tilemap.SetTile(_origin[tilemap], oldTile);
            selectedDictionary[tilemap] = tilePosition;
        }
    }
    private void SelectTile()
    {
        //Vector3 mousePosition = main.ScreenToWorldPoint(Input.mousePosition);
        //Vector3Int tilePosition = tilemap.WorldToCell(mousePosition);
        //tilePosition.z = 0;

        //if (tilemap.HasTile(tilePosition))
        //{
        //    tilemap.SetTransformMatrix(tilePosition, Matrix4x4.TRS(offSet, Quaternion.Euler(0,0,0), Vector3.one));
        //    tilemap.SetTransformMatrix(_previousPosition[tilemap], Matrix4x4.identity);
        //    _previousPosition[tilemap] = tilePosition;
        //}
        Vector3 mousePosition = main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePosition = tilemap.WorldToCell(mousePosition);
        tilePosition.z = 0;

        if (tilePosition != _previousPosition[tilemap])
        {
            if (tilemap.HasTile(tilePosition))
            {
                tilemap.SetTransformMatrix(tilePosition, Matrix4x4.TRS(offSet, Quaternion.Euler(0, 0, 0), Vector3.one));
            }
            if (tilemap.HasTile(_previousPosition[tilemap]))
            {
                tilemap.SetTransformMatrix(_previousPosition[tilemap], Matrix4x4.identity);
            }
            _previousPosition[tilemap] = tilePosition;
        }
    }

    private void StartFloodFill()
    {
        floodFill.Origin = _origin[tilemap];
        floodFill.Goal = _goal[tilemap];
        floodFill.tileMap = tilemap;
        floodFill.visitedTile = originTile;
        floodFill.pathTile = destinationTile;
        StartCoroutine(floodFill.FloodFill2D());
    }
    private void StartHeuristic()
    {
        heuristic.Origin = _origin[tilemap];
        heuristic.Goal = _goal[tilemap];
        heuristic.tileMap = tilemap;
        heuristic.visitedTile = originTile;
        heuristic.pathTile = destinationTile;
        StartCoroutine(heuristic.FloodFill2D());
    }
    private void StartDijkstra()
    {
        dijkstra.Origin = _origin[tilemap];
        dijkstra.Goal = _goal[tilemap];
        dijkstra.tileMap = tilemap;
        dijkstra.visitedTile = originTile;
        dijkstra.pathTile = destinationTile;
        StartCoroutine(dijkstra.FloodFill2D());
    }
    private void StartA()
    {
        aAlgorithm.Origin = _origin[tilemap];
        aAlgorithm.Goal = _goal[tilemap];
        aAlgorithm.tileMap = tilemap;
        aAlgorithm.visitedTile = originTile;
        aAlgorithm.pathTile = destinationTile;
        StartCoroutine(aAlgorithm.FloodFill2D());
    }
}
