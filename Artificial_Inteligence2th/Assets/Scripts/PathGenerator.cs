using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _circlePrefab;
    [SerializeField] private int _numOfPoints = 20;
    [SerializeField] private float _radius = 5f;

    private List<Vector2> _points = new List<Vector2>();
    public PathFollowing pathFollowing;
    private void Awake()
    {
        GeneratePoints();
        InstantiateCircles();
        
    }

    private void GeneratePoints()
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

    private void InstantiateCircles()
    {
        foreach (Vector2 point in _points)
        {
            Instantiate(_circlePrefab, point, Quaternion.identity);
        }
    }
}
