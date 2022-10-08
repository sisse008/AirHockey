using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

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


    public const int MainSceneIndex = 1;

    private void Awake()
    {
        if(instance && instance != this)
            Destroy(gameObject);
        
        DontDestroyOnLoad(gameObject);
    }
}
