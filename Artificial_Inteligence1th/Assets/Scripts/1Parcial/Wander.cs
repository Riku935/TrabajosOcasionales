using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    private Vector3 targetWander;
    public GameObject randomTransform;
    private Queue<Vector3> targetQueue = new Queue<Vector3>();
    private bool crRunning = false;


    [Header("Wander Attributes")]
    Vector3 velocity;
    Vector3 wanderForce;
    float randomAngle;

    public float circleRadius = 1;
    

    private void Start()
    {
        targetWander = transform.position;
    }
    private void Update()
    {
        CalculateWander();
        Debug.DrawLine(transform.position, velocity.normalized * 2, Color.green);
    }




    private void CalculateWander()
    {
        if (crRunning == false)
        {
            StartCoroutine(ChangeTarget());
            StartCoroutine(RandomAngle());
 
            crRunning = true;
        }
    }
    private void FillQueue()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomTarget = new Vector3(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-5f, 5f), 0);
            targetQueue.Enqueue(randomTarget);
        }
    }


    private void GetAngle()
    {
        Quaternion rotate = Quaternion.AngleAxis (randomAngle, Vector3.forward);
        var displacement = new Vector3(0, -1); 
        displacement = rotate * displacement;
    }

    IEnumerator RandomAngle()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            randomAngle = Random.value;
        }
    }

    IEnumerator ChangeTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (targetQueue.Count == 0) FillQueue();
            targetWander = targetQueue.Dequeue();
            print(targetWander);
            randomTransform.transform.position = targetWander;
        }
    }
}
