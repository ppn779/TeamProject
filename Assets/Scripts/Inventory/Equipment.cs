using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour {
    private Transform tr = null;
    private bool isEquipWeapon = false;
	private void Start () {
        tr = this.transform;	
	}
    public void Equip(GameObject item)
    {
        if (isEquipWeapon)
        {

        }
        else
        {
            GameObject go =  FindForName("Right Hand");
            Debug.Log(go.name);
            Instantiate(item, go.transform.position , go.transform.rotation , go.transform);
            //Instantiate(item);
        }
        
    }
    private GameObject FindForName(string equipmentName)
    {
        Transform[] trChild = tr.GetComponentsInChildren<Transform>();
        foreach(Transform trEach in trChild)
        {
            if (trEach.name.Contains(equipmentName))
            {
                return trEach.gameObject;
            }
        }
        Debug.Log("Cant FindForName [" + equipmentName + "]");
        return null;
    }
    private GameObject FindForTag(string equipmentTag)
    {
        GameObject[] goChild = tr.GetComponentsInChildren<GameObject>(true);
        foreach (GameObject go in goChild)
        {
            if (go.gameObject.CompareTag(equipmentTag))
            {
                return go;
            }
        }
        Debug.Log("Cant FindForTag [" + equipmentTag + "]");
        return null;
    }
}
