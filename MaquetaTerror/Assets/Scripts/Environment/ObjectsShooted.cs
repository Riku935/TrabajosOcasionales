using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsShooted : ShootBase
{
    public float shootsToBreak = 1;
    private float currentShoots = 0;
    public override void GetShoot()
    {
        base.GetShoot();

        currentShoots ++;
    }
    private void Update()
    {
        if (currentShoots>=shootsToBreak)
        {
            this.gameObject.SetActive(false);//solo para probar la efectividad del disparo
        }
    }
}
