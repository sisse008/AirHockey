using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Button))]
public class MenuButtonController : Animations, IAnimatableButton, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverAnimation();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        PlaySelectedAnimation();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ResetSize();
    }

    public void PlaySelectedAnimation()
    {
        ChangeColor();
    }
    public void PlayHoverAnimation()
    {
        Enlarge();
    }
}
