using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SelectionMenuController : MonoBehaviour
{
    [SerializeField] SelectionPath tableSelectionPath;
    [SerializeField] SelectionPath padsSelectionPath;

    static Camera selectionCamera;
    public static Vector3 CamPosition => selectionCamera.transform.position;


    [SerializeField] SelectionData TableSelectionItemsData;
    [SerializeField] SelectionData PudsSelectionItemsData;


    private UnityAction<bool> rotatePath;


    private void Awake()
    {
        selectionCamera = Camera.main;
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
}
