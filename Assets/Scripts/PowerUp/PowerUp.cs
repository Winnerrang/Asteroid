using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class PowerUp: MonoBehaviour
{
    [SerializeField]
    private float _timeToDie = 4f;

    public void Start()
    {
        Invoke("Destroy", _timeToDie);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    public abstract void PickUp();

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PickUp();
        }
    }
}
