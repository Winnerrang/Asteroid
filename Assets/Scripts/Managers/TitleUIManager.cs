using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneController.Instance.ChangeScene("MainScene");
    }
}
