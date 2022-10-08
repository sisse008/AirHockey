using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : Menu
{
    public float loadGameDelay;
    public override void StartNewGame()
    {
        StartCoroutine(WaitAndLoadScene(loadGameDelay));
    }

    IEnumerator WaitAndLoadScene(float secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(GameManager.MainSceneIndex, LoadSceneMode.Single);
    }

    public override void QuitGame()
    {
       base.QuitGame();
    }
}
