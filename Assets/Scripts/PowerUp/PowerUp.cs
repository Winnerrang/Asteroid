using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PowerUp: MonoBehaviour
{
    public abstract void PickUp();

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickUp();
        }
    }
}
