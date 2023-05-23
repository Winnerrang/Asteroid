using System.Collections;
using UnityEngine;


public abstract class PlayableObject : MonoBehaviour, IDamageable
{
    public Health _health = new Health();

    private Weapon _weapon;

    public abstract void Move(Vector3 direction, Vector2 target);

    public virtual void Move(Vector2 direction) { }

    public virtual void Move(float speed) { }
    public abstract void Shoot(Vector3 direction, float speed);

    public abstract void Die();
    public abstract void GetDamage(float damage);
}
