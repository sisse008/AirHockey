using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "SelectionMenuData", menuName = "ScriptableObjects/DataForSelectionMenu", order = 1)]
public class SelectionData : ScriptableObject
{

    public List<SelectionItem> SelectionItems;
    public int NumberOfItems => SelectionItems.Count;

    public List<SelectionItem> Items => new List<SelectionItem>(SelectionItems);


    public bool Contains(SelectionItem item)
    {
        foreach (SelectionItem _item in SelectionItems)
            if (item.id == _item.id)
                return true;
        return false;
    }
    public SelectionItem GetItem(int index)
    {
        if (index < NumberOfItems)
            return SelectionItems[index];
        return null;
    }


}
