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

    public GameObject EquipItem(int num)
    {
        if (itemList[num])
            return itemList[num];

        else {
            Debug.Log("장착 무기가 없음.");
            return null; }
    }

    public void HideItemNumber(int num) { itemList[num].SetActive(false); }
    public void ShowItemNumber(int num) { itemList[num].SetActive(true); }
}
