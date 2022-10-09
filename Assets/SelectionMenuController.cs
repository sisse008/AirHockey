using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SelectionMenuController : MonoBehaviour
{
    public SelectionPathController tableSelectionPath;
    public SelectionPathController padsSelectionPath;

    private UnityAction<bool> rotatePath;


    private void Start()
    {
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

    public void ExitSelectionScene()
    {
        SceneManager.LoadScene(GameManager.MenuSceneIndex, LoadSceneMode.Single);
    }
}
