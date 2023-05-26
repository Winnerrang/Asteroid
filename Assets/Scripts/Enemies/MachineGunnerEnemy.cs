using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunnerEnemy : Enemy
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;

    // The machine Gun Enemy will try to move to a radius that is close to the player
    [SerializeField] private float _shootingRadius;

    [Range(0, float.PositiveInfinity)]
    [SerializeField] private float _shootingInterval;

    private float _timer;
    protected override void Start()
    {
        base.Start();
        _timer = _shootingInterval;
        _name = "Machine Gunner Enemy";
        _weapon = new Weapon("Machine Gun", _bulletDamage, _bulletSpeed);
    
    }

    protected override void Update()
    {
        RotateToward(_target.position);
        if (Vector3.Distance(transform.position, _target.position) >= _shootingRadius)
        {
            Move(_target);
        }
        else
        {
            if (_timer >= _shootingInterval)
            {
                Shoot(Vector3.zero, 0f);
                _timer = 0;
            }
        }

        _timer += Time.deltaTime;
        

    }

    //public override void Move(Vector3 direction, Vector2 target)
    //{
    //    Vector2 diff;
    //    Debug.Log(target);
    //    diff = target - (Vector2)transform.position;

    //    //Move the enemy toward the player
    //    direction = diff.normalized;
    //    transform.position += direction * _speed * Time.deltaTime;

    //}

    //public void Rotate(Vector2 target)
    //{
    //    Vector2 diff;
    //    Debug.Log(target);
    //    diff = target - (Vector2)transform.position;

    //    // always face the enemy toward the player
    //    float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
    //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    //}
}
