using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    [Header("Manager")]
    [SerializeField]
    private ScoreManager _scoreManager;
    public ScoreManager ScoreManagerInstance => _scoreManager;

    [SerializeField]
    private UIManager _uiManager;
    public UIManager UIManagerInstance => _uiManager;

    [SerializeField]
    List<GameObject> _enemyPrefabs;

    [SerializeField]
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

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _spawnInterval)
        {
            _timer = 0f;
            CreateRandomEnemy();
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
