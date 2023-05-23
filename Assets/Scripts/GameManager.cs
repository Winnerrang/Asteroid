using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    [SerializeField]
    GameObject _enemyPrefab;

    private GameObject tempObject;

    private void Awake()
    {
        if(_instance == null) _instance = this;
        else Destroy(_instance.gameObject);
    }

    void CreateEnemy()
    {
        
    }
}
