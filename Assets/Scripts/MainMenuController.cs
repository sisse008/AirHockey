using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : Menu
{
    // [SerializeField] private Button startButton;
    // [SerializeField] private Button quitButton;

    public override void StartNewGame()
    {
        // load scene
        SceneManager.LoadScene(GameManager.MainSceneIndex, LoadSceneMode.Single);

    }

    public override void QuitGame()
    {
       base.QuitGame();
    }
}
