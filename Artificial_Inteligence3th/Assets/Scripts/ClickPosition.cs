using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickPosition : MonoBehaviour
{
    public Tilemap tilemap;

    private void Start()
    {
        //tilemap = GetComponent<Tilemap>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Click();
        }
    }

    private void Click()
    {
        Vector3Int cellPosition = tilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        Debug.Log("Clicked on tile at position (" + cellPosition.x + ", " + cellPosition.y + ")");
    }
}
