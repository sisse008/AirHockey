using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class Selectable : Highlightable, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public static UnityAction<Selectable> OnItemSelected;
    public GameObject gameItem;
    public int id;

    //TODO: set selectable to true only when is displayed on screen
    //TODO: find a better way to calculate distance from from camera threshhold
    protected bool selectable => (transform.position - SelectionMenuController.CamPosition).magnitude < 101f;

    public static Selectable currentlySelected;


    private AudioSource selectedSound;

    protected override void Awake() 
    {
        selectedSound = GetComponent<AudioSource>();
        base.Awake();
    }

    protected virtual void OnEnable()
    {
        currentlySelected = null;
    }

    public bool IsEqual(Selectable item)
    {
        return item.id == id;
    }
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (selectable)
            Highlight();
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (!selectable)
            return;

        selectedSound.Play();
        OnItemSelected?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(currentlySelected != this)
            UnHighlight();
    }
}
