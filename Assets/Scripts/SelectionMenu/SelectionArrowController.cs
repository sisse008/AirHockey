using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectionArrowController : Animations, IAnimatableButton, IPointerEnterHandler, IPointerExitHandler
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
       
    }
    public void PlayHoverAnimation()
    {
        Enlarge();
    }
}
