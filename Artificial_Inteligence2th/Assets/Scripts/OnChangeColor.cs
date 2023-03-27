using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnChangeColor : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        ChangeColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeColor();
    }
    private void ChangeColor()
    {
        Color newColor = new Color(Random.value, Random.value, Random.value, 1.0f);
        _renderer.material.color = newColor;
    }
}
