using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionMenuController : MonoBehaviour
{

    public SelectionPath pathBuilderObject;

    public SelectionMenuUIController menuUIController;

    static Camera selectionCamera;
    public static Vector3 CamPosition => selectionCamera.transform.position;

    [SerializeField] SelectionData[] selectionData;

    public Dictionary<SelectionData, SelectionPath> itemsSelectionMenuData = 
        new Dictionary<SelectionData, SelectionPath>();   
    

    private UnityAction<bool> rotatePath;


    private void Awake()
    {
        selectionCamera = Camera.main;
    }

  
    private void Start()
    {

        foreach (SelectionData _selectionData in selectionData)
        {
            SelectionPath pathBuilder = Instantiate(pathBuilderObject);
            pathBuilder.Init(_selectionData.SelectionItems);

            itemsSelectionMenuData.Add(_selectionData, pathBuilder);

            menuUIController.AddButton(_selectionData.ItemGroupName, 
                () => ActivateSelectionPath(pathBuilder));
        }

        ActivateSelectionPath(itemsSelectionMenuData[selectionData[0]]);
    }

    public void NextItem(bool clockwise)
    {
        rotatePath?.Invoke(clockwise);
    }

 
    void ActivateSelectionPath(SelectionPath activate)
    {
        foreach (SelectionPath path in itemsSelectionMenuData.Values)
        {
            path.gameObject.SetActive(false);
        }
       
        activate.gameObject.SetActive(true);
        rotatePath = activate.NextItem;
    }
}
