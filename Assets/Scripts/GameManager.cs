using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public GameObject hockeyTable;

    public GameObject pad1;
 
    public GameObject pad2;

    public enum GameType
    {
        SINGLE_PLAYER,
        MULTIPLE_PLAYER
    };

    public GameType gameType = GameType.SINGLE_PLAYER;


    public static GameManager Instance
    {
        get
        {
            if (instance)
                return instance;
            instance = FindObjectOfType<GameManager>();
            return instance;
        }
    }


    public const int MainSceneIndex = 2;
    public const int SlectionSceneIndex = 1;
    public const int MenuSceneIndex = 0;

    private void Awake()
    {
        if(instance && instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }
    public void SwitchToGameScene(float loadSceneDelay)
    {
        StartCoroutine(WaitAndLoadScene(loadSceneDelay, MainSceneIndex));
    }

    IEnumerator WaitAndLoadScene(float secs, int sceneIndex)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    public void LoadSelectionScene(float loadSceneDelay)
    {
        StartCoroutine(WaitAndLoadScene(loadSceneDelay, SlectionSceneIndex));
    }

    public void SwitchToMainMenuScene(float loadSceneDelay)
    {
        StartCoroutine(WaitAndLoadScene(loadSceneDelay, MenuSceneIndex));
    }


}
