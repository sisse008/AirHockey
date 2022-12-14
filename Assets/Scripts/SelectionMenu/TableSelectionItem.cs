using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TableSelectionItem : SelectionItem
{
    public static UnityAction<SelectionItem> OnTableSelected;

    protected override void OnEnable()
    {
        OnTableSelected += TableSelected;
        base.OnEnable();
    }
    private void OnDisable()
    {
        OnTableSelected -= TableSelected;
    }
    void TableSelected(SelectionItem item)
    {
        if (item != this) { UnHighlight(); }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!selectable)
            return;
        currentlySelected = this;
        OnTableSelected?.Invoke(this);
        base.OnPointerDown(eventData);  
    }
}
