using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Button))]
public class MenuButtonController : Animations, IAnimatableButton, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{

    AudioSource hoverSound;

    protected override void Awake()
    {
        hoverSound = GetComponent<AudioSource>();
        base.Awake();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        PlayHoverSound();
        PlayHoverAnimation();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        PlayPressedSound();
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

    void PlayHoverSound()
    {
        hoverSound.pitch = 1;
        hoverSound.Play();
    }

    void PlayPressedSound()
    {
        hoverSound.pitch = 1.5f;
        hoverSound.Play();
    }
}
