using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    private string _name;
    private float _damage;
    private float _bulletSpeed;

    public Weapon() 
    {
        _name = null;
        _damage = 0f;
    }
    public Weapon(string name, float damage)
    {
        _name = name;
        _damage = damage;
    }

    public Weapon(string name, float damage, float bulletSpeed) : this(name, damage)
    {
        _bulletSpeed = bulletSpeed;
    }

    public void Shoot(Bullet bullet, PlayableObject player, string targetting, float timeToDie)
    {
        // the bullet travelling direction will the same as the player's facing direction
        Bullet tempBullet = GameObject.Instantiate(bullet, player.transform.position, player.transform.rotation);
        tempBullet.SetBullet(_damage, _bulletSpeed, timeToDie, targetting);
    }
}
