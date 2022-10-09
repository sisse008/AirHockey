using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "SelectionMenuData", menuName = "ScriptableObjects/DataForSelectionMenu", order = 1)]
public class SelectionData : ScriptableObject
{
   [SerializeField]
    private List<SelectionItem> SelectionItems;

    public int NumberOfItems => SelectionItems.Count;

    public List<SelectionItem> Items => new List<SelectionItem>(SelectionItems);

    public GameObject GetItem(int index)
    {
        if (index < NumberOfItems)
            return SelectionItems[index].gameObject;
        return null;
    }

}
