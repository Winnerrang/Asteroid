using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultUIManager : MonoBehaviour
{

    //#########################################################Score Display##################################################//
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private TextMeshProUGUI _highScoreText;

    public void UpdateScore()
    {
        _scoreText.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
        _highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    //#########################################################Button Callback##################################################//

    public void Restart()
    {
        SceneController.Instance.ChangeScene("MainScene");
    }


    //#########################################################Others##################################################//
    private void Start()
    {
        UpdateScore();
    }

}
