using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;


    //############################################Manager########################################//
    [Header("Manager")]
    [SerializeField]
    private ScoreManager _scoreManager;
    public ScoreManager ScoreManagerInstance => _scoreManager;

    [SerializeField]
    private UIManager _uiManager;
    public UIManager UIManagerInstance => _uiManager;




    //############################################Enemy Spawn########################################//

    [SerializeField]
    List<GameObject> _enemyPrefabs;

    [SerializeField]
    float _initialSpawnInterval=3f;

    [SerializeField]
    float _maxSpawnRate = 10;

    [Tooltip("The spawnInterval will decrease every 10s")]
    [SerializeField]
    float _spawnDerivative = 0.2f;

    float _decreaseTimer;

    float _spawnInterval;

    private float _timer = 0f;

    private GameObject tempObject;

    [Header("PowerUp")]
    [SerializeField]
    private NukeBag _nukeBag;
    public NukeBag NukeBagInstance => _nukeBag;

    [SerializeField]
    private GunPowerUpController _gunPowerUpController;
    public GunPowerUpController GunPowerUpControllerInstance => _gunPowerUpController;

    [Header("PlayerRelated")]
    [SerializeField] private FiringRateController _firingRateController;
    public FiringRateController FiringRateControllerInstance => _firingRateController;

    private void Awake()
    {
        if(_instance == null) _instance = this;
        else Destroy(_instance.gameObject);
    }

    private void Start()
    {
        
        _spawnInterval = _initialSpawnInterval;
        _decreaseTimer = 0f;
    }

    private void Update()
    {
        IncreaseSpawnRate();

        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            _timer = 0f;
            CreateRandomEnemy();
        }
    }

    private void IncreaseSpawnRate()
    {
        float spawnRate = 1 / _spawnInterval;
        
        if (spawnRate >= _maxSpawnRate)
        {
            _spawnInterval = 1 / _maxSpawnRate;
            return;
        }

        _decreaseTimer += Time.deltaTime;

        if (_decreaseTimer >= 10f)
        {
            _decreaseTimer = 0f;
            _spawnInterval -= _spawnDerivative;

            _spawnInterval = Mathf.Clamp(_spawnInterval, 1 / _maxSpawnRate, float.MaxValue);
            Debug.Log($"{1 / _maxSpawnRate}");
        }

    }

    void CreateRandomEnemy()
    {
        int index = Random.Range(0, _enemyPrefabs.Count);

        tempObject = Instantiate(_enemyPrefabs[index], GenerateRandomPosition(), Quaternion.identity);
    }

    /// <summary>
    /// Generate a random position that is on the screen boundary
    /// </summary>
    /// <returns></returns>
    private Vector3 GenerateRandomPosition()
    {
        float degree = Random.Range(0f, 360f);
        float slope = Mathf.Tan(degree * Mathf.Deg2Rad);
        

        float width = Camera.main.scaledPixelWidth;
        float height = Camera.main.scaledPixelHeight;

        float breakPoint = Mathf.Atan(height / width) * Mathf.Rad2Deg;
        float x, y;

        if (degree > 0 && degree <= breakPoint)
        {
            x = width / 2;
            y = x * slope;
        }
        else if (degree > breakPoint && degree <=  180 - breakPoint)
        {
            y = height / 2;
            x = y / slope;
        }else if (degree > 180 - breakPoint && degree < 180 + breakPoint)
        {
            x = - width/ 2;
            y = x * slope;
        }
        else
        {
            y = - height / 2;
            x = y / slope;
        }

        x += width / 2;
        y += height / 2;

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector2(x, y));
        worldPosition.z = 0f;
        return worldPosition;
    }
}
