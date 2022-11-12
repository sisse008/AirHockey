using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public Dictionary<int, GameManager.GameTypeEnum> gameTypeIndex = new Dictionary<int, GameManager.GameTypeEnum>()
    {
        { 0, GameManager.GameTypeEnum.MULTIPLE_PLAYER},
        { 1, GameManager.GameTypeEnum.SINGLE_PLAYER}
    };
    private void OnEnable()
    {
       // if (Tools.IsMobile())
            StartCoroutine(DisableMultiPlayerOption());
        UpdateDropdownValue();
        dropdown.onValueChanged.AddListener(UpdateGameType);
    }

    private void OnDisable()
    {
        dropdown.onValueChanged.RemoveAllListeners();
    }

    bool disabled = false;
    private IEnumerator DisableMultiPlayerOption()
    {
        while (true)
        {
            yield return new WaitUntil(() => dropdown.IsExpanded);
            if (disabled == false)
            {
                DisableOption(GameManager.GameTypeEnum.MULTIPLE_PLAYER);
                disabled = true;
            }
            yield return new WaitUntil(() => dropdown.IsExpanded == false);
            disabled = false;
        }
    }

    private void DisableOption(GameManager.GameTypeEnum type)
    {
        Toggle[] toggles = dropdown.gameObject.GetComponentsInChildren<Toggle>();
        foreach (KeyValuePair<int, GameManager.GameTypeEnum> item in gameTypeIndex)
        {
            if (item.Value == type)
            {
                toggles[item.Key].interactable = false;
            }
        }

    }
    private void UpdateDropdownValue()
    {
        foreach (KeyValuePair<int, GameManager.GameTypeEnum> item in gameTypeIndex)
        {
            if (item.Value == GameManager.Instance.GameType)
                dropdown.value = item.Key;
        }
    }
    private void UpdateGameType(int val)
    {
        foreach (KeyValuePair<int, GameManager.GameTypeEnum> item in gameTypeIndex)
        {
            if (item.Key == val)
                GameManager.Instance.GameType = item.Value;
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
