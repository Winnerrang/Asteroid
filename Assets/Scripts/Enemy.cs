using System.Collections;
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

    //public override void Move(Vector3 direction, Vector2 target)
    //{
    //    Vector2 diff;
    //    Debug.Log(target);
    //    diff = target - (Vector2)transform.position;


    //    // always face the enemy toward the player
    //    float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
    //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    //    //Move the enemy toward the player
    //    direction = diff.normalized;
    //    transform.position += direction * _speed * Time.deltaTime;

    //}

    //public override void Move(Vector2 direction)
    //{
    //    transform.position = Vector2.MoveTowards(transform.position, _target.position, 0.01f);
    //}

    //public override void Move(float speed)
    //{
    //    transform.Translate(Vector2.right * speed * Time.deltaTime);
    //}

    public override void Shoot(Vector3 direction, float speed)
    {
        _weapon.Shoot(_bulletPrefab, this, "Player", 5f);
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
