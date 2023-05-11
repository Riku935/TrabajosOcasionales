using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Villager : MonoBehaviour
{
    public GameObject player;
    public Player script;

    public List<Vector3Int> nodos = new List<Vector3Int>();
    public int currentNode;

    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
        nodos = script._pathNodes;
        player.transform.position = nodos[currentNode];

        }
    }
}
