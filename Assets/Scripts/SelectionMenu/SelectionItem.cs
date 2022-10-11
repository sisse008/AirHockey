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

    public bool IsEqual(SelectionItem item)
    {
        return item.id == id;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Highlight();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        OnItemSelected?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UnHighlight();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 1.5f, 0, Space.Self);
    }
}
