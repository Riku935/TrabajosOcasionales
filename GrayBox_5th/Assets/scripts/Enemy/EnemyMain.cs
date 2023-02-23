using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public int life = 100;

    private void Update()
    {
        if(life == 0)
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            life -= 50;
            print(life);
        }
    }
}
