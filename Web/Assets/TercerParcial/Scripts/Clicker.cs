using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clicker : MonoBehaviour
{
    public int clickCount;
    public TMP_Text clickCountText;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;
            anim.Play("penguin_jump");
        }
        updateScore();
    }
    public void updateScore()
    {
        clickCountText.text = "" + clickCount;
    }
    public void ButtonAction()
    {
        //Accion de JavaScript
    }
}
