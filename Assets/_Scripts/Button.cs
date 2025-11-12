using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public bool triggered = false;

    public Mover triggerobject;

    public Sprite PressedSprite;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            triggerobject.moving = true;
            SpriteRenderer spriteR = GetComponent<SpriteRenderer>();

            spriteR.sprite = PressedSprite;
        }
    }
}
