using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public GameObject hockeyTable;

    public GameObject pad1;
 
    public GameObject pad2;




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
}
