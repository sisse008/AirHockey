using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SelectionMenuController : MonoBehaviour
{
    public SelectionPath tableSelectionPath;
    public SelectionPath padsSelectionPath;

    public static Camera selectionCamera;


    public SelectionData TableSelectionItemsData;
    public SelectionData PudsSelectionItemsData;


    private UnityAction<bool> rotatePath;


    private void Awake()
    {
        selectionCamera = Camera.main;
    }

    private void OnEnable()
    {
        TableSelectionItem.OnTableSelected += (item) => { GameManager.Instance.hockeyTable = item.gameItem; };
        PadSelectionItem.OnPadSelected += (item) => { GameManager.Instance.pad1 = item.gameItem; };
    }
    private void Start()
    {
        tableSelectionPath.Init(TableSelectionItemsData.SelectionItems);
        padsSelectionPath.Init(PudsSelectionItemsData.SelectionItems);

        ActivateTableSelectionPath();
    }

    public void NextItem(bool clockwise)
    {
        rotatePath?.Invoke(clockwise);
    }
    public void ActivateTableSelectionPath()
    {
        tableSelectionPath.gameObject.SetActive(true);
        padsSelectionPath.gameObject.SetActive(false);

        rotatePath = tableSelectionPath.NextItem;
    }

    public void ActivatePadSelectionPath()
    {
        tableSelectionPath.gameObject.SetActive(false);
        padsSelectionPath.gameObject.SetActive(true);

        rotatePath = padsSelectionPath.NextItem;
    }

    public void BacktoMainMenuScene()
    {
        GameManager.Instance.SwitchToMainMenuScene(0f);
    }

    public void StartNewGame()
    {
        GameManager.Instance.SwitchToGameScene(0.2f);
    }
}
