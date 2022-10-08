using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ButtonController : ButtonAnimations, IAnimatableButton
{
    Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData)
    {
        PlayHoverAnimation();
    }
    public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        PlaySelectedAnimation();
    }

    public void PlaySelectedAnimation()
    {
        ChangeColor();
    }
    public void PlayHoverAnimation()
    {
        EnlargeButton();
    }
}
