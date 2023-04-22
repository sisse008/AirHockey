using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SelectionMenuUIController : MonoBehaviour
{
    public Button selectionMenuButton;
    public Transform buttonsHolder;

    List<Button> allButtons = new List<Button>();
    public void AddButton(string name, UnityAction OnClick)
    {
        Button b = Instantiate(selectionMenuButton, buttonsHolder);
        b.gameObject.SetActive(true);
        b.onClick.AddListener(OnClick);
        b.GetComponentInChildren<TMP_Text>().text = name; 
        allButtons.Add(b);
    }

    private void OnDisable()
    {
        //not needed. the buttons are destroyed with the scene
        foreach(Button b in allButtons)
            b.onClick.RemoveAllListeners();
    }
}
