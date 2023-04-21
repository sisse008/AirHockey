using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "SelectionMenuData", menuName = "ScriptableObjects/DataForSelectionMenu", order = 1)]
public class SelectionData : ScriptableObject
{

    public List<Selectable> SelectionItems;
    public int NumberOfItems => SelectionItems.Count;

    public List<Selectable> Items => new List<Selectable>(SelectionItems);


    public bool Contains(Selectable item)
    {
        foreach (Selectable _item in SelectionItems)
            if (item.id == _item.id)
                return true;
        return false;
    }
    public Selectable GetItem(int index)
    {
        if (index < NumberOfItems)
            return SelectionItems[index];
        return null;
    }


}
