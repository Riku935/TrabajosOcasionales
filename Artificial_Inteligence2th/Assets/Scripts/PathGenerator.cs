using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


public class PathGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _formPrefab;
    [SerializeField] private int _numOfPoints = 20;
    [SerializeField] private float _radius = 5f;
    private List<Vector2> _points = new List<Vector2>();
    public PathFollowing pathFollowing;

    [SerializeField] private int numOfPositions = 10;
    [SerializeField] private Vector3 minRange;
    [SerializeField] private Vector3 maxRange;
    public List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        //GenerateCircle();
        //InstantiateCircles();
        GenerateRandom();
        InstantiateVector();
    }
    private void GenerateCircle()
    {
        float angle = 0f;
        float angleStep = 360f / _numOfPoints;

        for (int i = 0; i < _numOfPoints; i++)
        {
            float x = _radius * Mathf.Cos(angle * Mathf.Deg2Rad);
            float y = _radius * Mathf.Sin(angle * Mathf.Deg2Rad);

            Vector2 point = new Vector2(x, y);
            _points.Add(point);
            pathFollowing.nodes.Add(point);
            angle += angleStep;
        }
    }
    private void GenerateRandom()
    {
        for (int i = 0; i < numOfPositions; i++)
        {
            Vector3 newPosition = new Vector3(
                Random.Range(minRange.x, maxRange.x),
                Random.Range(minRange.y, maxRange.y),
                Random.Range(minRange.z, maxRange.z)
            );
            positions.Add(newPosition);
            pathFollowing.nodes.Add(newPosition);
        }
    }
    private void InstantiateCircles()
    {
        foreach (Vector2 point in _points)
        {
            Instantiate(_formPrefab, point, Quaternion.identity);
        }
    } 
    private void InstantiateVector()
    {
        foreach (Vector3 position in positions)
        {
            Instantiate(_formPrefab, position, Quaternion.identity);
        }
    }
}
