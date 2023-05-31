using System.Collections;
using UnityEngine;


public abstract class PlayableObject : MonoBehaviour, IDamageable
{
    public Health _health = new Health();

    protected Weapon _weapon;

    [SerializeField]
    protected float _speed;

    public virtual void Move(Transform target)
    {
        Vector2 diff = target.position - transform.position;
        diff.Normalize();
        transform.Translate(diff * _speed * Time.deltaTime, Space.World); 

    }
    
    public virtual void Move(Vector2 direction) 
    { 
        transform.Translate(direction * _speed * Time.deltaTime, Space.World); 
    }

    public virtual void RotateToward(Vector2 target)
    {
        Vector2 source = transform.position;
        Vector2 diff;
        //calculate the difference between target position and player position
        diff = target - source;

        //calculate the angle the player should be facing
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public abstract void Shoot(Vector3 direction, float speed);

    public abstract void Die();
    public abstract void GetDamage(float damage);
}
