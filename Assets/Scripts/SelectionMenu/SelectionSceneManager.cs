using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionSceneManager : MonoBehaviour
{

    private void OnEnable()
    {
        TableSelectionItem.OnObjectSelected += (item) => { GameManager.Instance.hockeyTable = item.gameItem; };
        PadSelectionItem.OnObjectSelected += (item) => { GameManager.Instance.pad1 = item.gameItem; };
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
