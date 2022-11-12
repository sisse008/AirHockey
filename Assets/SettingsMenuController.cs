using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsMenuController : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public Dictionary<int, GameManager.GameType> gameTypeIndex = new Dictionary<int, GameManager.GameType>()
    {
        { 0, GameManager.GameType.MULTIPLE_PLAYER},
        { 1, GameManager.GameType.SINGLE_PLAYER}
    };
    private void OnEnable()
    {
        UpdateDropdownValue();
        dropdown.onValueChanged.AddListener(UpdateGameType);
    }

    private void OnDisable()
    {
        dropdown.onValueChanged.RemoveAllListeners();
    }

    private void UpdateDropdownValue()
    {
        foreach (KeyValuePair<int, GameManager.GameType> item in gameTypeIndex)
        {
            if (item.Value == GameManager.Instance.gameType)
                dropdown.value = item.Key;
        }
    }
    private void UpdateGameType(int val)
    {
        foreach (KeyValuePair<int, GameManager.GameType> item in gameTypeIndex)
        {
            if (item.Key == val)
                GameManager.Instance.gameType = item.Value;
        }
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
