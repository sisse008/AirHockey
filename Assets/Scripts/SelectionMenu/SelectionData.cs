using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class SelectionData<T> : ScriptableObject
{

    public List<SelectionItem<T>> SelectionItems;
    public int NumberOfItems => SelectionItems.Count;

    public List<SelectionItem<T>> Items => new List<SelectionItem<T>>(SelectionItems);


    public bool Contains(SelectionItem<T> item)
    {
        foreach (SelectionItem<T> _item in SelectionItems)
            if (item.id == _item.id)
                return true;
        return false;
    }
    public SelectionItem<T> GetItem(int index)
    {
        if (index < NumberOfItems)
            return SelectionItems[index];
        return null;
    }


}
