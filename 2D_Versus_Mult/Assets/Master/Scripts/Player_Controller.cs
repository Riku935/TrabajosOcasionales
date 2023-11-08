using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;
public class Player_Controller : FSM
{
    [Header("Player_Settings")]
    [SerializeField] float velocidad = 5.0f;
    [SerializeField] float JumpForce;
    [SerializeField] float attackRadius;
    [SerializeField] bool isplayerDead;
    [SerializeField] int playerLife;

    private Animator anim;
    private SpriteRenderer spr;

    private void Start()
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Walk();
        Flip();
        Death();
    }

    private void FixedUpdate()
    {
        
    }
    private void Flip() 
    {
        if (Input.GetAxis("Horizontal") >= 0.1)
        {
            spr.flipX = false;
        }
        if (Input.GetAxis("Horizontal") <= -0.1)
        {
            spr.flipX = true;
        }
    }

    private void Walk()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoX = movimientoHorizontal * velocidad * Time.deltaTime;
        transform.Translate(new Vector3(movimientoX, 0, 0));
        anim.SetFloat("Horizontal", Mathf.Abs(movimientoHorizontal));
    }
    private void Death()
    {
        if (playerLife == 0)
        {
            velocidad = 0;

        }
    }
}
