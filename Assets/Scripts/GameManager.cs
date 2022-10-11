using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    [SerializeField]
    private GameObject hockeyTable;
    [SerializeField]
    private GameObject pad;

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

    public void SelectedTable(GameObject table)
    {
        hockeyTable = table;
    }
    public void SelectedPad(GameObject pad)
    {
        this.pad = pad;
    }
}
