using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public float loadSceneDelay;
    public void StartNewGame()
    {
        StartCoroutine(WaitAndLoadScene(loadSceneDelay, GameManager.MainSceneIndex));
    }

    public void LoadSelectionScene()
    {
        StartCoroutine(WaitAndLoadScene(loadSceneDelay, GameManager.SlectionSceneIndex));
    }

    IEnumerator WaitAndLoadScene(float secs, int sceneIndex)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
