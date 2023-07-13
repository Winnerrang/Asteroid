using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    //#############################################################Health#######################################################//
    [SerializeField]
    private TextMeshProUGUI _healthUI;

    //#############################################################Score#######################################################//
    [SerializeField]
    private TextMeshProUGUI _cuurentScoreUI, _highScoreUI;


    //#############################################################Power Up#######################################################//
    [Header("Nuke")]
    [SerializeField] private GameObject _nukeArea;
    [SerializeField] private GameObject _nukeUIPrefab;

    [Header("Gun")]
    [SerializeField] private GunPowerUpUI _gunUI;

    public void OnEnable()
    {
        GameManager gameManager;
        if (GameManager.Instance == null)
        {
            gameManager = GameObject.FindObjectOfType<GameManager>();
        }
        else
        {
            gameManager = GameManager.Instance;
        }

        gameManager.ScoreManagerInstance.OnCurScoreChanged.AddListener(ChangeCurrentScore);
        gameManager.ScoreManagerInstance.OnHighScoreChanged.AddListener(ChangeHighScore);

        //nuke
        gameManager.NukeBagInstance.OnNumberOfNukeChanged.AddListener(OnNumberOfNukeChanged);

        //health
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player?.OnPlayerHealthChanged.AddListener(ChangeHealth);
    }

    private void ChangeHealth(int health)
    {
        _healthUI.text = health.ToString();
    }

    private void OnDisable()
    {
        GameManager.Instance.ScoreManagerInstance.OnCurScoreChanged.RemoveListener(ChangeCurrentScore);
        GameManager.Instance.ScoreManagerInstance.OnHighScoreChanged.RemoveListener(ChangeHighScore);

        GameManager.Instance.NukeBagInstance.OnNumberOfNukeChanged.RemoveListener(OnNumberOfNukeChanged);

        //health
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player?.OnPlayerHealthChanged.RemoveListener(ChangeHealth);
    }

    public void ChangeCurrentScore(int value)
    {
        _cuurentScoreUI.text = value.ToString();
    }

    public void ChangeHighScore(int value)
    {
        Debug.Log($"UI changed {value}");
        _highScoreUI.text = value.ToString();
    }

    public void OnNumberOfNukeChanged(int number)
    {
        int numberOfUI = _nukeArea.transform.childCount;

        if (numberOfUI == number) return;

        if (numberOfUI < number)
        {
            for (int i = 0; i < number - numberOfUI; i++)
            {
                GameObject.Instantiate(_nukeUIPrefab, _nukeArea.transform);
            }
        }
        else
        {
            for (int i = 0; i < numberOfUI - number; i++)
            {
                Destroy(_nukeArea.transform.GetChild(0).gameObject);
            }
        }
        
        
    }

    public void SetGunUIFilledAmount(float amount)
    {
        _gunUI.SetFillAmount(amount);
    }
}
