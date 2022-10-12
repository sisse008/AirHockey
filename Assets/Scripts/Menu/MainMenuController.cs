using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public float loadSceneDelay;
    public void StartNewGame()
    {
        GameManager.Instance.SwitchToGameScene(loadSceneDelay);
    }

    public void LoadSelectionScene()
    {
        GameManager.Instance.LoadSelectionScene(loadSceneDelay);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
