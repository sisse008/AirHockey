using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TSelectionItem<T> : SelectionItem
{
    public static UnityAction<SelectionItem> OnObjectSelected;

    protected override void OnEnable()
    {

        OnObjectSelected += ObjectSelected;
        base.OnEnable();
    }
    private void OnDisable()
    {
        OnObjectSelected -= ObjectSelected;
    }

    void ObjectSelected(SelectionItem item)
    {
        if (item != this) { UnHighlight(); }
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!selectable)
            return;
        currentlySelected = this;
        OnObjectSelected?.Invoke(this);
        base.OnPointerDown(eventData);
    }
}
