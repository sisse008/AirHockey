using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PadSelectionItem : SelectionItem
{
    public static UnityAction<SelectionItem> OnPadSelected;

    protected override void OnEnable()
    {
        OnPadSelected += (item) => { if (item != this) { UnHighlight(); } };
        base.OnEnable();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        selected = this;
        OnPadSelected?.Invoke(this);
        base.OnPointerDown(eventData);
    }
}
