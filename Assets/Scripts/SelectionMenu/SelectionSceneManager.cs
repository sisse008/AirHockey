using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSceneManager : MonoBehaviour
{
    public void BacktoMainMenuScene()
    {
        GameManager.Instance.SwitchToMainMenuScene(0f);
    }

    public void StartNewGame()
    {
        GameManager.Instance.SwitchToGameScene(0.2f);
    }
}
