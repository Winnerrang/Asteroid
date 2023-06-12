using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    [SerializeField]
    private float _damage;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private string _targetTag;

    private float _timeToDie;

    private bool _isDie = false;

    private float _timer = 0;

    public void SetBullet(float damage, float speed, float timeToDie, string tag)
    {
        _damage = damage;
        _speed = speed;
        _timeToDie = timeToDie;
        _targetTag = tag;
    }
    void Move()
    {
        // move the bullet in the direction it is facing
        // (0, 1, 0) is the facing direction of the bullet relative to itself
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    }

    void Damage(IDamageable damageable)
    {

        damageable.GetDamage(_damage);
        Die();
    }

    void Die()
    {
        if( _isDie )
        {
            return;
        }
        _isDie = true;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag != _targetTag)
        {
            return;
        }

        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Damage(damageable);
        }
    }

    private void Update()
    {
        Move();
        _timer += Time.deltaTime;
        if (_timer >= _timeToDie)
        {
            Die();
        }
    }
}
