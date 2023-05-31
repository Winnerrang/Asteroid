using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _cuurentScoreUI, _highScoreUI;

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
    }

    private void OnDisable()
    {
        GameManager.Instance.ScoreManagerInstance.OnCurScoreChanged.RemoveListener(ChangeCurrentScore);
        GameManager.Instance.ScoreManagerInstance.OnHighScoreChanged.RemoveListener(ChangeHighScore);
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

}
