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

    //TODO: set selectable to true only when is desplayed on screen
    protected bool selectable;

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

    private void Start()
    {
        selectable = true;
    }

    public bool IsEqual(SelectionItem item)
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
        if(selected != this)
            UnHighlight();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 1.5f, 0, Space.Self);
    }
}
