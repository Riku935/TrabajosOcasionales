using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Interaction : MonoBehaviour
{
    public GameObject key;
    public bool canOpen = false;
    [SerializeField] private float distanceToOpen;
    private void Start()
    {
        
    }
    private void Update()
    {
        float distBetween = Vector3.Distance(this.transform.position, key.transform.position);
        if (distBetween <= distanceToOpen || canOpen == true)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
        if (distBetween >= distanceToOpen)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
