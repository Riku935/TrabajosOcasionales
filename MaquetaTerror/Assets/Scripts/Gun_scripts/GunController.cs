using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Gun Settings")]
    public float fireRate = 0.2f;
    public int chargerSize = 30;   //Cantidad total de balas en el cargador
    public int reservedAmmo = 350; //Cantidad total de balas en la reserva

    bool canShoot;
    int currentCharger;  //Cantidad actual de balas en el cargador
    int currentReserved; //Cantidad actual de balas en la reserva

    [Header("Aim Settings")]
    public Vector3 normalLocalPosition;
    public Vector3 aimingLocalPosition;
    public float aimSmooth = 1f;

    [Header("Running Settings")]
    public Vector3 runningLocalPosition;

    [Header("Ray/Bullet Settings")]
    public float ShootDistance = 10;

    [Header("VFX")]
    public ParticleSystem flash;
    public ParticleSystem shellDrop;

    [Header("Audio")]
    public AudioClip shootEffectSound;
    private AudioSource audioSource;


    private void Start()
    {
        currentCharger = chargerSize;
        currentReserved = reservedAmmo;
        audioSource = GetComponent<AudioSource>();
        canShoot = true; //Tobias Esto tenemos que iniciarlo desde el GameManager
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && canShoot && currentCharger > 0)
        {
            canShoot = false;
            currentCharger--;
            StartCoroutine(ShootGun());
        }
        else if (Input.GetKeyDown(KeyCode.R) && currentCharger < chargerSize && reservedAmmo > 0)
        {
            int ammoNeeded = chargerSize - currentCharger;
            if (ammoNeeded >= currentReserved)
            {
                currentCharger += currentReserved;
                currentReserved -= ammoNeeded;
            }
            else
            {
                currentCharger = chargerSize;
                currentReserved -= ammoNeeded;
            }
        }
        ShowRay();
        Aim();
        //Run();
    }
    private void Aim()
    {
        Vector3 target = normalLocalPosition;  //Posicion por default
        if (Input.GetMouseButton(1))
        {
            target = aimingLocalPosition;
        }
        Vector3 desiredPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * aimSmooth);
        transform.localPosition = desiredPosition;
    }

    private void Run()
    {
        Vector3 target = normalLocalPosition;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            target = runningLocalPosition;
        }
        Vector3 desiredPosition = Vector3.Lerp(transform.localPosition, target, Time.deltaTime * aimSmooth);
        transform.localPosition = desiredPosition;
    }

    private void Recoil()
    {
        transform.localPosition -= Vector3.forward * 0.1f;
    }

    private void Fire()
    {
        RaycastHit hit;
        audioSource.clip = shootEffectSound;
        audioSource.PlayOneShot(shootEffectSound, 0.7f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, ShootDistance, LayerMask.GetMask("Enemy")))//lanza un rayo a la distancia establecida e interactua con el layermask
        {
            /* Transform objectHit = hit.transform;
             Debug.Log(hit.transform.name);*/
            //hit.transform.GetComponent<ShootBase>().GetShoot();//manda a llamar el override de los codigos 
            hit.transform.gameObject.SetActive(false);
        }

    }
    private void ShowRay() //Este lo usamos un rato, cuando hagamos el build, quitamos este metodo
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * ShootDistance;
        Debug.DrawRay(transform.position, forward, Color.red);
    }

    IEnumerator ShootGun()
    {
        Recoil();
        Fire();
        flash.Play();
        shellDrop.Play();
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }
}
