using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    [SerializeField]
    private float _damage;

    [SerializeField]
    private float _speed;

    public void SetBullet(float damage, float speed)
    {
        _damage = damage;
        _speed = speed;
    }
    void Move()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    void Damage(IDamageable damageable)
    {
        Debug.Log($"damage");
        damageable.GetDamage(_damage);
        //Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageable = collision.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Damage(damageable);
        }
    }
}
