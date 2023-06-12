using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GunPowerUpController : MonoBehaviour
{

    private float _timer;

    [SerializeField]
    [Tooltip("Duration of the power up")]
    [Range(0f, float.PositiveInfinity)]
    private float _duration=5f;

    [SerializeField]
    [Tooltip("Percentage of the increase in firing rate")]
    [Range(0f, float.PositiveInfinity)]
    private float _increasePercentage = 1f;

    private Coroutine _coroutine;

    private FiringRateController _controller;
    private UIManager _ui;

    private void Start()
    {
        _timer = 0;
        _controller = GameManager.Instance.FiringRateControllerInstance;
        _ui = GameManager.Instance.UIManagerInstance;
    }

    public void EquipPower()
    {
        _timer = _duration;

        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(IncreaseShootingRate(_increasePercentage));
        }
        
    }

    private IEnumerator IncreaseShootingRate(float percent)
    {
        //double the firing Rate
        _controller.ChangeMultiplier(percent);

        while (_timer > 0)
        {
            _ui.SetGunUIFilledAmount(_timer / _duration);
            yield return null;
            _timer -= Time.deltaTime;
        }
        _timer = 0;
        _coroutine = null;
        _controller.ChangeMultiplier(-percent);
    }
}
