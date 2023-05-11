using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Reflection;

public class PlayerController : MonoBehaviour
{
    public bool playerSelected;
    //public Player player;

    public Vector3 mousePositionn;

    public Tilemap tilemap;

    private RaycastHit2D hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (playerSelected)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int cellPosition = tilemap.WorldToCell(mousePosition);
                mousePositionn = cellPosition;
                Debug.Log("Clicked on cell position: " + cellPosition);
            }
            if (hit.collider != null && hit.collider.GetComponent<SpriteRenderer>() != null && !playerSelected)
            {
                Debug.Log("El jugador ha sido seleccionado.");
                Debug.Log(hit.collider.gameObject.name);
                playerSelected = true;
            }
        }
        Mover();
    }
    //void Moverse()
    //{
    //    for (int i = player._pathNodes.Count - 1; i >= 0; i--)
    //    {

    //    }
    //}
    void Mover()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            hit.collider.transform.position = mousePositionn;
        }
    }
}
