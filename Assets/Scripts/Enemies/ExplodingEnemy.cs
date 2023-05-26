using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEnemy : Enemy
{

    private Rigidbody2D _rigidBody;

    [SerializeField]
    private int _explodeDamage = 10;


    protected override void Start()
    {
        base.Start();
        _rigidBody = GetComponent<Rigidbody2D>();

        // no weapon for exploding enemy, it will explode itself
        _name = "Exploding Enemy";
        _weapon = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            // if the enemy collides with the player, it will explode
            Player p = collision.gameObject.GetComponent<Player>();
            p.GetDamage(_explodeDamage);
            Die();
        }
    }

    
}
