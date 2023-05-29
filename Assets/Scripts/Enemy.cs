﻿using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy: PlayableObject
{
    public static int numberOfEnemies;

    protected string _name;


    protected EEnemyType _enemyType;

    protected Transform _target;

    [SerializeField]
    private Bullet _bulletPrefab;


    public void Awake()
    {
        AddEnemy();
    }

    protected virtual void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;    
    }

    protected virtual void Update()
    {
        if (_target != null)
        {
            Move(transform);
        }
        else
        {
            Move(Vector2.up);
        }
    }



    public override void Shoot(Vector3 direction, float speed)
    {
        _weapon.Shoot(_bulletPrefab, this, "Player", 5f, speed, direction);
    }
    
    public void Shoot(float speed)
    {
        _weapon.Shoot(_bulletPrefab, this, "Player", 5f, speed);
    }

    public virtual void Attack()
    {

    }

    public override void Die()
    {
        Debug.Log($"{_name} Die");
        SubtractEnemy();
        Destroy(gameObject);
    }

    public void SetEnemyType(EEnemyType enemyType)
    {
        _enemyType = enemyType;
    }

    public static void AddEnemy()
    {
        numberOfEnemies++;
    }

    public static void SubtractEnemy()
    {
        numberOfEnemies--;
    }

    public override void GetDamage(float damage)
    {
        _health.CurrentHealth -= (int)damage;
        if (_health.CurrentHealth <= 0)
        {
            Die();
        }
    }
}
