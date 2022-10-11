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
        OnTableSelected += (item) => { if (item != this) { UnHighlight(); } };
        base.OnEnable();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        selected = this;
        OnTableSelected?.Invoke(this);
        base.OnPointerDown(eventData);  
    }
}
