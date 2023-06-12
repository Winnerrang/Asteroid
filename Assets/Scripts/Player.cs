using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player: PlayableObject, IDamageable
{
    private string _name;

    private Rigidbody2D _rigidBody;

    [SerializeField]
    private Camera _camera;


    [SerializeField]
    private float _weaponDamage, _weaponSpeed, _timeToDie;

    [SerializeField]
    private Bullet _bulletPrefab;

    private FiringRateController _firingRateController;

    private float _timer = 0f;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _firingRateController = GameManager.Instance.FiringRateControllerInstance;
        _weapon = new Weapon("Player's Weapon", _weaponDamage, _weaponSpeed);
    }

    public void Move(Vector2 direction, Vector2 target)
    {
        RotateToward(target);
        Move(direction);
    }

    public override void Shoot(Vector3 direction, float speed)
    {

        if (!_firingRateController.CanShoot) return;

        _weapon.Shoot(_bulletPrefab, this, "Enemy", _timeToDie, _weaponSpeed);
        _firingRateController.ResetTimer();
    }




    public override void Die()
    {
        Debug.Log("Player Die");
    }

    public override void GetDamage(float damage)
    {
        Debug.Log("Player Take Damage");
    }


}
