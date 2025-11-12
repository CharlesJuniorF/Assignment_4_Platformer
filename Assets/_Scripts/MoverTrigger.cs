using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverTrigger : MonoBehaviour
{

    public bool triggered = false;

    public Mover triggerobject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            triggerobject.moving = true;
        }
    }
}
