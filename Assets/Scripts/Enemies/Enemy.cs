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

    [SerializeField]
    private GameObject _DieEffectPrefab;

    private AudioSource m_audioSource;

    private SpriteRenderer m_spriteRenderer;

    private Collider2D m_collider;

    protected bool m_isDie = false;

    public bool IsDie => m_isDie;

    public void Awake()
    {
        AddEnemy();
        m_spriteRenderer = transform.Find("Texture").GetComponent<SpriteRenderer>();
        m_audioSource = GetComponent<AudioSource>();
        m_collider = GetComponent<Collider2D>();
    }

    protected virtual void Start()
    {
        _target = GameObject.FindWithTag("Player")?.transform;    
    }

    protected virtual void Update()
    {
        if (_target != null)
        {
            Move(_target);
        }
        else
        {
            Move(Vector2.up);
        }
    }



    public override void Shoot(Vector3 direction, float speed)
    {
        _weapon.Shoot(_bulletPrefab, this, "Player", 5f, speed, direction);
    }
    
    public void Shoot(float speed)
    {
        _weapon.Shoot(_bulletPrefab, this, "Player", 5f, speed);
    }

    public virtual void Attack()
    {

    }

    public override void Die()
    {
        //Debug.Log($"{_name} Die");
        m_isDie = true;
        m_collider.enabled = false;
        GameObject DieVFX = Instantiate(_DieEffectPrefab, transform.position, Quaternion.identity);
        Destroy(DieVFX, 1.5f);
        SubtractEnemy();
        m_spriteRenderer.enabled = false;
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
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
        GameManager.Instance.ScoreManagerInstance.IncrementScore(1);

        m_audioSource.Play();
        Die();
        
        //_health.CurrentHealth -= (int)damage;
        //if (_health.CurrentHealth <= 0)
        //{
        //    Die();
        //}
    }
}
