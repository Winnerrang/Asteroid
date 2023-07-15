using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{

    private int _curScore;

    private int _highScore;

    public UnityEvent<int> OnCurScoreChanged;

    public UnityEvent<int> OnHighScoreChanged;

    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        
        CurScore = 0;
    }
    private int CurScore
    {
        get { return _curScore; }
        set
        {
            _curScore = value;
            OnCurScoreChanged?.Invoke(value);

            PlayerPrefs.SetInt("CurrentScore", _curScore);
            PlayerPrefs.Save();
            if (_curScore > _highScore)
            {
                HighScore = CurScore;
            }
        }
    }

    private int HighScore
    {
        get { return _highScore; }
        set
        {
            Debug.Log($"High Score {value}");
            _highScore = value;
            OnHighScoreChanged?.Invoke(value);
            PlayerPrefs.SetInt("HighScore", value);
            PlayerPrefs.Save();
        }
    }

    public void IncrementScore(int delta)
    {
        CurScore += delta;
    }
}
