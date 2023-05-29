using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDamage;

    // The machine Gun Enemy will try to move to a radius that is close to the player
    [SerializeField] private float _shootingRadius;

    [Range(0, float.PositiveInfinity)]
    [SerializeField] private float _shootingInterval;

    private LineRenderer _lineRenderer;
    private float _timer;
    protected override void Start()
    {
        base.Start();
        _timer = _shootingInterval;
        _name = "Machine Gunner Enemy";
        _weapon = new Weapon("Machine Gun", _bulletDamage, _bulletSpeed);
        _lineRenderer = GetComponent<LineRenderer>();
    }

    protected override void Update()
    {
        if (_target == null) return;

        RotateToward(_target.position);

        _lineRenderer.positionCount = 0;
        if (Vector3.Distance(transform.position, _target.position) >= _shootingRadius)
        {
            Move(_target);
        }
        else
        {
            _lineRenderer.positionCount = 2;
            _lineRenderer.SetPosition(0, transform.position);
            _lineRenderer.SetPosition(1, _target.position);
            if (_timer >= _shootingInterval)
            {
                Shoot(_bulletSpeed);
                _timer = 0;
            }
        }

        _timer += Time.deltaTime;


    }

}
