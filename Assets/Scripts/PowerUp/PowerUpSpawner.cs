using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{

    [SerializeField]
    private float _spawnInterval = 5f;

    [SerializeField]
    List<PowerUp> _powerUpPrefabs;

    private Vector3 _bottomLeft, _topRight;

    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        _topRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        _timer = 0f;
    }

    private Vector3 RandomizePosition()
    {
        Vector3 result;
        result.z = 0f;

        result.x = Random.Range(_bottomLeft.x, _topRight.x);
        result.y = Random.Range(_bottomLeft.y, _topRight.y);

        return result;

    }
    // Update is called once per frame
    void Update()
    {

        _timer -= Time.deltaTime;

        if (_timer <= 0f ) {
            GenerateRandomPowerUp();
            _timer = _spawnInterval;
        }
        
    }

    private void GenerateRandomPowerUp()
    {
        if (_powerUpPrefabs.Count == 0) return;

        int index = Random.Range(0, _powerUpPrefabs.Count);

        PowerUp _newPowerUp = Instantiate(_powerUpPrefabs[index], transform);

        _newPowerUp.transform.position = RandomizePosition();
    }
}
