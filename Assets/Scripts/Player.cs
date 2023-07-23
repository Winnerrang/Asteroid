using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

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

    [SerializeField]
    private GameObject _dieEffectPrefab;

    private FiringRateController _firingRateController;

    private float _timer = 0f;

    public UnityEvent<int> OnPlayerHealthChanged;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _firingRateController = GameManager.Instance.FiringRateControllerInstance;
        _weapon = new Weapon("Player's Weapon", _weaponDamage, _weaponSpeed);
        _health.MaxHealth = 100;
        _health.CurrentHealth = _health.MaxHealth;
        OnPlayerHealthChanged?.Invoke(_health.CurrentHealth);
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

        GameObject DieVFX = Instantiate(_dieEffectPrefab, transform.position, Quaternion.identity);
        Invoke("ChangeScene", 1.5f);
        gameObject.SetActive(false);
        
        
    }

    private void ChangeScene()
    {
        SceneController.Instance.ChangeScene("GameOverScene");
    }

    public override void GetDamage(float damage)
    {
        _health.CurrentHealth -= (int) damage;

        OnPlayerHealthChanged?.Invoke(_health.CurrentHealth);
        if (_health.CurrentHealth <= 0)
        {
            Die();
        }
    }


}
