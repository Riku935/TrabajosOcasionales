using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform player;

    public float timer = 5;
    private float bulletTime;

    public GameObject enemyBullet;
    public Transform spawnPoint;
    public float enemyspeed;
    void Start()
    {
        
    }

    void Update()
    {
        enemy.SetDestination(player.position);
        ShootAtPlayer();
    }
    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;

            bulletTime = timer;
            GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
            bulletRig.AddForce(bulletRig.transform.forward * enemyspeed);
            Destroy(bulletObj, 5f);
        
    }

}
