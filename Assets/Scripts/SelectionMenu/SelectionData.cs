using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "SelectionMenuData", menuName = "ScriptableObjects/DataForSelectionMenu", order = 1)]
public class SelectionData : ScriptableObject
{
   [SerializeField]
    private List<GameObject> SelectionItems;

    public int NumberOfItems => SelectionItems.Count;

    public List<GameObject> Items => new List<GameObject>(SelectionItems);

    public GameObject GetItem(int index)
    {
        if (index < NumberOfItems)
            return SelectionItems[index];
        return null;
    }

}
