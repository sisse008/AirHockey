using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSceneManager : MonoBehaviour
{

    void SetSelectTable(SelectionItem<TableController> selectedItem) =>
        GameManager.Instance.hockeyTable = selectedItem.Object;

    void SetSelectPad(SelectionItem<PadController> selectedItem) =>
       GameManager.Instance.pad1 = selectedItem.Object;


    private void OnEnable()
    {
        TableSelectionItem.OnObjectSelected += SetSelectTable;
        PadSelectionItem.OnObjectSelected += SetSelectPad;
    }

    private void OnDisable()
    {
        //because the events are static, they do not die with the selection item object.
        //if i dont unsubscribe for the event, they will hold on to this object after it dies.
        //thats why static events are dangerous. must remember to unsubscribe.
        TableSelectionItem.OnObjectSelected -= SetSelectTable;
        PadSelectionItem.OnObjectSelected -= SetSelectPad;
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
