using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Enemy: PlayableObject
{
    public static int numberOfEnemies;

    private string _name;

    [SerializeField]
    private float _speed;

    EEnemyType _enemyType;

    protected Transform _target;

    public Enemy()
    {
        AddEnemy();
    }

    private void Start()
    {
        _target = GameObject.FindWithTag("Player").transform;    
    }

    protected virtual void Update()
    {
        if (_target != null)
        {
            
            Move(_target.position);
        }
        else
        {
            Move(_speed);
        }
    }

    public override void Move(Vector3 direction, Vector2 target)
    {

    }

    public override void Move(Vector2 direction)
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, 0.01f);
    }

    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    public override void Shoot(Vector3 direction, float speed)
    {

    }
    
    public virtual void Attack()
    {

    }

    public override void Die()
    {
        Debug.Log($"{_name} Die");
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
        
    }
}
