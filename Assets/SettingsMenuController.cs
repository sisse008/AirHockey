using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsMenuController : MonoBehaviour
{
    public void UpdateGameTypeToSinglePlayer()
    {
        GameManager.Instance.gameType = GameManager.GameType.SINGLE_PLAYER;
    }
    public void UpdateGameTypeToMultiplePlayer()
    {
        GameManager.Instance.gameType = GameManager.GameType.MULTIPLE_PLAYER;
    }

    public void UpdateGameType(TMP_Dropdown change)
    {
        if (change.value == 0)
            UpdateGameTypeToSinglePlayer();
        else
            UpdateGameTypeToMultiplePlayer();
    }
}
