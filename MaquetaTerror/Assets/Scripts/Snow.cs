using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public GameObject Player;
    public float snowOffset;
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + snowOffset, Player.transform.position.z);
    }
}
