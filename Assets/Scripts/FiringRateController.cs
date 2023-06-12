using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringRateController : MonoBehaviour
{
    [SerializeField]
    private float _baseShootingRate = 3f;

    private float _shootingRateMultiplier = 1f;
    public float ShootingRate => _baseShootingRate * _shootingRateMultiplier;

    public float ShootingInterval => 1 / ShootingRate;

    private float _CDTimer;

    public bool CanShoot => _CDTimer <= 0;

    public void ChangeMultiplier(float percent)
    {
        _shootingRateMultiplier += percent;

        if (_CDTimer > ShootingInterval) _CDTimer = ShootingInterval;
    }

  
    public void ResetTimer()
    {
        _CDTimer = ShootingInterval;
    }


    private void Start()
    {
        _CDTimer = 0f;
    }

    private void Update()
    {
        if (_CDTimer >= 0)
        {
            _CDTimer -= Time.deltaTime;
        }
    }
}
