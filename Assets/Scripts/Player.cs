using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player: PlayableObject, IDamageable
{
    private string _name;

    [SerializeField]
    private float _speed;

    private Rigidbody2D _rigidBody;

    [SerializeField]
    private Camera _camera;

    private Weapon _weapon;

    [SerializeField]
    private float _weaponDamage, _weaponSpeed, _timeToDie;

    [SerializeField]
    private Bullet _bulletPrefab;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        _weapon = new Weapon("Player's Weapon", _weaponDamage, _weaponSpeed);
    }

    public override void Move(Vector3 direction, Vector2 target)
    {
        
        _rigidBody.velocity = direction * _speed * Time.deltaTime;
    
        Vector3 screenPosition = _camera.WorldToScreenPoint(transform.position);

        target.x -= screenPosition.x;
        target.y -= screenPosition.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public override void Shoot(Vector3 direction, float speed)
    {
        _weapon.Shoot(_bulletPrefab, this, "Enemy", _timeToDie);
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
