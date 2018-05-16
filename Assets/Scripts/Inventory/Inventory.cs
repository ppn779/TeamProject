using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    private List<GameObject> itemList = new List<GameObject>();
    public List<GameObject> ItemList { get { return itemList; } }

    private void Start ()
    {
	}
    public void AddItem(GameObject goItem)
    {
        itemList.Add(goItem);
    }
    public void RemoveItemInNumber(int num)
    {
         itemList.RemoveAt(num);
    }
    public void HideItemNumber(int num) { itemList[num].SetActive(false); }
    public void ShowItemNumber(int num) { itemList[num].SetActive(true); }
}
