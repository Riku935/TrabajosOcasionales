using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            GameManager.obj.gameReady = true;
        }
        AnimationMove();
    }
    void AnimationMove()
    {
        if (GameManager.obj.like == true)
        {
            anim.Play("penguin_jump");
            //anim.SetTrigger("Tr_jump");
        }
        if (GameManager.obj.Dislike == true)
        {
            anim.Play("penguin_slide");
        }
        if (GameManager.obj.Reaload== true)
        {
            anim.Play("penguin_idle");
        }
        if (GameManager.obj.next == true)
        {
            anim.Play("penguin_walk");
        }
    }
}
