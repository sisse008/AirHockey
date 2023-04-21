using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectionItem<T> : Selectable<T>
{
    public static UnityAction<SelectionItem<T>> OnObjectSelected;


    protected override void Awake()
    {
        gameObject.AddComponent<Rotate>();

        base.Awake();

    }
    protected override void OnEnable()
    {
        OnObjectSelected += ObjectSelected;
        base.OnEnable();
    }
    private void OnDisable()
    {
        OnObjectSelected -= ObjectSelected;
    }

    void ObjectSelected(Selectable<T> item)
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
