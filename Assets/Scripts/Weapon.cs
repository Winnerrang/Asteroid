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

    public void Shoot(Bullet bulletPrefab, PlayableObject player, string targetting, float timeToDie)
    {
        // the bullet travelling direction will the same as the player's facing direction
        Bullet tempBullet = GameObject.Instantiate(bulletPrefab, player.transform.position, player.transform.rotation);
        tempBullet.SetBullet(_damage, _bulletSpeed, timeToDie, targetting);
    }

    public void Shoot(Bullet bulletPrefab, PlayableObject player, string targetting, float timeToDie, float bulletSpeed)
    {
        _bulletSpeed = bulletSpeed;
        Shoot(bulletPrefab, player, targetting, timeToDie);
    }

    public void Shoot(Bullet bulletPrefab, PlayableObject player, string targetting, float timeToDie, float bulletSpeed, Vector3 direction)
    {
        _bulletSpeed = bulletSpeed;
        Bullet tempBullet = GameObject.Instantiate(bulletPrefab, player.transform.position, Quaternion.LookRotation(direction));
        tempBullet.SetBullet(_damage, _bulletSpeed, timeToDie, targetting);
    }


}
