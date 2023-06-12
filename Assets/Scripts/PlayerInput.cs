using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player _player;

    private float _horizontal, _vertical;

    private Vector2 _lookTarget;

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _lookTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            _player.Shoot(Vector3.zero, 0f);
        }

        if (Input.GetMouseButtonDown(1))
        {
            GameManager.Instance.NukeBagInstance.UseNuke();
        }


    }

    private void FixedUpdate()
    {
        _player.Move(new Vector3(_horizontal, _vertical, 0f), _lookTarget);
    }
}
