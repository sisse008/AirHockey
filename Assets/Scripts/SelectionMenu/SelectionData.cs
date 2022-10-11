using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "SelectionMenuData", menuName = "ScriptableObjects/DataForSelectionMenu", order = 1)]
public class SelectionData : ScriptableObject
{

    public List<SelectionItem> SelectionItems;


    [SerializeField]
    private SelectionItem selectedItem;

    public int NumberOfItems => SelectionItems.Count;

    public List<SelectionItem> Items => new List<SelectionItem>(SelectionItems);


    public bool Contains(SelectionItem item)
    {
       //TODO;
        return false;
    }
    public SelectionItem GetItem(int index)
    {
        if (index < NumberOfItems)
            return SelectionItems[index];
        return null;
    }

    public void SetSelectedItem(SelectionItem selectedItem)
    {
        this.selectedItem = selectedItem;
    }

    public SelectionItem GetSelectedItem()
    {
        if (selectedItem)
            return selectedItem;
        return SelectionItems[0];
    }

}
