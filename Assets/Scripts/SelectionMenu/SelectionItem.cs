using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectionItem : Highlightable, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public static UnityAction<SelectionItem> OnItemSelected;
    public GameObject gameItem;
    public int id;

    public static SelectionItem selected;


    private AudioSource selectedSound;

    private void Awake()
    {
        selectedSound = GetComponent<AudioSource>();
    }

    protected virtual void OnEnable()
    {
        selected = null;
    }

    public bool IsEqual(SelectionItem item)
    {
        return item.id == id;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Highlight();
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        selectedSound.Play();
        OnItemSelected?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(selected != this)
            UnHighlight();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 1.5f, 0, Space.Self);
    }
}
